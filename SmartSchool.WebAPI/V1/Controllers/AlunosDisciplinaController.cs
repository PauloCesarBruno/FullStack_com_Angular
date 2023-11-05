using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Versão 01 do meu controlador de Alunos.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunosDisciplinaController : ControllerBase
    {

        public IRepository _repo;        

        /// <summary>
        /// Método responsável por retornar apenas um Aluno(a) por meio do Código Id, da Versão 01.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunosDisciplinaController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por registrar nova disciplina para um aluno especifico, trazendo tambem o professor no front da Versão 01.
        /// </summary>
        /// <returns></returns>
         [HttpPost]
        public ActionResult PostAD(AlunoDisciplina alunoDisciplinal)
        {
           if (alunoDisciplinal is null)
            {
                return BadRequest();
            }

            _repo.Add(alunoDisciplinal);

            _repo.SaveChangesAsync();
        
            return Ok(alunoDisciplinal);
          
        }  
    }
}