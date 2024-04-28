using apindien2.Models;
using apindien2.Models.DTO;
using apindien2.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apindien2.Controller;

[Route("api/villa")]
[ApiController]
public class VillaApiController : ControllerBase
{
    private readonly ILogger<VillaApiController> logger;
    private readonly IVillaRepository _dbVilla;
    private readonly IMapper _mapper;
    public VillaApiController(ILogger<VillaApiController> _logger, IVillaRepository dbVilla, IMapper mapper)
    {
        logger = _logger;
        _dbVilla = dbVilla;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
    {
        IEnumerable<Villa> villas = await _dbVilla.GetAll();
        return Ok(_mapper.Map<List<VillaDTO>>(villas));
    }

    [HttpGet("{id:int}", Name = "getVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VillaDTO>> GetVilla(int id)
    {
        var villa = await _dbVilla.Get(u => u.Id == id);
        if (villa == null)
        {
            logger.LogError("C'est pas trouvééé pelooo");
            return NotFound();
        }

        return Ok(_mapper.Map<VillaDTO>(villa));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaDTOCreate villa)
    {
        if (await _dbVilla.Get(v => v.Name.ToLower() == villa.Name.ToLower()) != null)
        {
            ModelState.AddModelError("Erreur de fou", "Villa en double !");
            return BadRequest(ModelState);
        }

        if (villa == null) return BadRequest(villa);


        Villa model = _mapper.Map<Villa>(villa);

        await _dbVilla.Create(model);

        return CreatedAtRoute("getVilla", new { id = model.Id }, model);
    }

    [HttpDelete("{id:int}", Name = "deleteVilla")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVilla(int id)
    {
        var villa = await _dbVilla.Get(v => v.Id == id);
        if (villa == null) return NotFound();
        _dbVilla.Remove(villa);
        return NoContent();
    }

    [HttpPut("{id:int}", Name = "updateVilla")]
    public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaDTOUpdate villaDTO)
    {
        
        var villa = await _dbVilla.Get(v => v.Id == id);

        if (villa == null) return NotFound();
        
        Villa model = _mapper.Map<Villa>(villaDTO);

        await _dbVilla.Update(model);

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "updatePartiaVilla")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePartialVilla(int id, [FromBody] JsonPatchDocument<VillaDTOUpdate> patchDTO)
    {
        if (id == null || patchDTO == null) return BadRequest();

        var villa = await _dbVilla.Get(v => v.Id == id, false);
        if (villa == null) return NotFound();

        VillaDTOUpdate villaDTO = _mapper.Map<VillaDTOUpdate>(villa);

        patchDTO.ApplyTo(villaDTO, ModelState);

        Villa model = _mapper.Map<Villa>(villaDTO);

        await _dbVilla.Update(model);
        
        return NoContent();
    }
}