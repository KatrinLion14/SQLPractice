using UniversityWebApi.Domain;
using UniversityWebApi.Dto;
using UniversityWebApi.Repositories;

namespace UniversityWebApi.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        public int CreateProfessor(ProfessorDto professor)
        {
            if (professor == null)
            {
                throw new Exception($"{nameof(Professor)} not found");
            }
            Professor professorEntity = professor.ConvertToProfessor();
            return _professorRepository.Create(professorEntity);
        }

        public void DeleteProfessor(string email)
        {
            Professor professor = _professorRepository.GetByEmail(email);
            if (professor == null)
            {
                throw new Exception($"{nameof(Professor)} not found, #Email - {email}");
            }
            _professorRepository.Delete(professor);
        }

        public List<Professor> GetAllProfessors()
        {
            return _professorRepository.GetAll();
        }

        public Professor GetProfessorByEmail(string email)
        {
            Professor professor = _professorRepository.GetByEmail(email);
            if (professor == null)
            {
                throw new Exception($"{nameof(Professor)} not found, #Email - {email}");
            }
            return professor;
        }

        public int UpdateProfessor(ProfessorDto professor)
        {
            if (professor == null)
            {
                throw new Exception($"{nameof(Professor)} not found");
            }
            Professor professorEntity = professor.ConvertToProfessor();
            Professor professorTemp = _professorRepository.GetByEmail(professorEntity.Email);
            if (professorTemp == null)
            {
                throw new Exception($"{nameof(Professor)} not found");
            }
            return _professorRepository.Update(professorEntity);
        }
    }
}
