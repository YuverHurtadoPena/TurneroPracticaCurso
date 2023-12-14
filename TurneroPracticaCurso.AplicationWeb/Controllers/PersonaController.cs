using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TurneroPracticaCurso.BLL.Dto;
using TurneroPracticaCurso.BLL.Interfaces;
using TurneroPracticaCurso.BLL.Mapper;

namespace TurneroPracticaCurso.AplicationWeb.Controllers
{
    [Controller]
    public class PersonaController : Controller
    {
        private readonly ITMapper _mapper;
        private readonly IPersonaService _personaService;
        private readonly  IRolService _rolService;



        public PersonaController(ITMapper mapper, IPersonaService personaService, IRolService rolService)
        {
            _mapper = mapper;
            _personaService = personaService;
            _rolService = rolService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(_mapper.ConvertPeronaOfEntityToVM(await _personaService.ObtenerPersonas()));
        }
        /* [HttpGet]
         public async Task<IActionResult> ListarRol()
         {
             List<RolDto> ListaRol = _mapper.ConvertRolOfEntityToVM(await _rolService.ListaRol());

             return StatusCode(StatusCodes.Status200OK, ListaRol);
         }*/

        [HttpGet]
        public async Task<JsonResult> ListarRol()
        {
            List<RolDto> ListaRol = _mapper.ConvertRolOfEntityToVM(await _rolService.ListaRol());
            return Json(ListaRol);
        }


        /*  [HttpGet]
          public async Task<IActionResult> ListaPersona()
          {

              personaList = _mapper.ConvertPeronaOfEntityToVM(await _personaService.ObtenerPersonas());
              return StatusCode(StatusCodes.Status200OK, personaList);
          }*/
    }
}
