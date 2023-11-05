using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;



namespace SmartSchool.WebAPI.V2.Controllers
{
    /// <summary>
    /// Versão 01 do meu controlador de Alunos.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunosDisciplinaController : ControllerBase
    {

        public IRepository _repo;        

        /// <summary>
        /// Método responsável por retornar apenas um Aluno(a) por meio do Código Id, da Versão 02.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunosDisciplinaController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por registrar nova disciplina para um aluno especifico, trazendo tambem o professor no front da Versão 02.
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