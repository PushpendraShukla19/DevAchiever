using Microsoft.AspNetCore.Mvc;
using QMS.RepositoryServices;

namespace QMS.Controllers
{
    public class QuizController : Controller
    {
        private readonly CertificateRepository _repository;

        public QuizController()
        {
            _repository = new CertificateRepository();
        }
       
        public async Task<IActionResult> Index()
        {
            var certificates = await _repository.GetAllCertificatesAsync();
            return View(certificates);
        }

        public async Task<IActionResult> StartCertification(int Id)
        {
            var Questions = await _repository.GetAllQuestionsAsync(Id);
            return View(Questions);
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
