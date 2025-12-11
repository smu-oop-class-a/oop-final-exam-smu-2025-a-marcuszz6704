using OOP.FinalTerm.Exam.Model;

namespace OOP.FinalTerm.Exam.Repository
{
    public interface IDirectorRepository
    {
    
        void AddDirector(DirectorModel director);

     
        List<DirectorModel> GetAllDirectors();

      
        DirectorModel GetDirectorById(int id);
    }
}