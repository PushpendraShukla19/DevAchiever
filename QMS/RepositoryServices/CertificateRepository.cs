using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QMS.Controllers;
using QMS.Models;
using QMS.RepositoryServices;
using System;
using System.Text.Json;

namespace QMS.RepositoryServices
{
    public class CertificateRepository
    {
        private readonly string _filePath = @"E:\Skeleton\QMS\QMS\DAL\Certificates.json";

        public async Task<List<Certificates>> GetAllCertificatesAsync()
        {
            try
            {
                var basePath = AppContext.BaseDirectory;
                var projectDir = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.FullName
                                 ?? basePath;
                var mockResponsePath = Path.Combine(projectDir, "DAL", $"Certificates.json");

                if (!File.Exists(mockResponsePath))
                    return new List<Certificates>();

                var json = await File.ReadAllTextAsync(mockResponsePath);
                var certificates = JsonSerializer.Deserialize<List<Certificates>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return certificates ?? new List<Certificates>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Certificates.json: {ex.Message}");
                return new List<Certificates>();
            }
        }

        public async Task<CertificationQuestion> GetAllQuestionsAsync(int Id)
        {
            try
            {
                var basePath = AppContext.BaseDirectory;
                var projectDir = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.FullName
                                 ?? basePath;
                var mockResponsePath = Path.Combine(projectDir, "DAL", $"Questions.json");

                if (!File.Exists(mockResponsePath))
                    return new CertificationQuestion();

                var json = await File.ReadAllTextAsync(mockResponsePath);
                var AllCertificatesQuestions = JsonSerializer.Deserialize<List<CertificationQuestion>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var certificates = AllCertificatesQuestions!.FirstOrDefault(q => q.CertificationId == Id);

                return certificates ?? new CertificationQuestion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Questions.json: {ex.Message}");
                return new CertificationQuestion();
            }
        }
    }
}