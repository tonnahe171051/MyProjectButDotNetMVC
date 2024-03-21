using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        Member? GetById(int id);
        void Insert(Member member);
        void Update(Member member);
        void Remove(int id);
        Member? GetByEmail(string email);
        public Member Login(string email, string password);
    }

}
