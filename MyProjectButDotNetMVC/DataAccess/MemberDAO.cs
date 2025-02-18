﻿using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO? instance;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new MemberDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetAll()
        {
            using var context = new FstoreContext();
            List<Member> list = context.Members.ToList();
            return list;
        }

        public Member? GetById(int id)
        {
            using var context = new FstoreContext();
            Member? member = context.Members.SingleOrDefault(m => m.MemberId == id);
            return member;
        }

        public Member? GetByEmail(string email)
        {
            using var context = new FstoreContext();
            Member? member = context.Members
                .SingleOrDefault(m => m.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return member;
        }

        public void Add(Member member)
        {
            if (GetById(member.MemberId) != null)
                throw new Exception("Member has existed");
            using var context = new FstoreContext();
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void Update(Member member)
        {
            if (GetById(member.MemberId) == null)
                throw new Exception("Member does not exist");
            using var context = new FstoreContext();
            context.Members.Update(member);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Member? member = GetById(id);
            if (member == null)
                throw new Exception("Member does not exist");
            using var context = new FstoreContext();
            context.Members.Remove(member);
            context.SaveChanges();
        }

        public Member Login(string email, string password)
        {
            Member? member = null;
            try
            {
                IEnumerable<Member> members = GetAll().Append(GetDefaultMember());
                member = members.SingleOrDefault(mb =>
                    mb.Email != null &&
                    mb.Email.Equals(email) &&
                    mb.Password.Equals(password));
                if (member == null)
                {
                    throw new Exception("Login failed! Please check your email and password!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public Member GetDefaultMember()
        {
            Member Default = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                string email = config["account:defaultAccount:email"];
                string password = config["account:defaultAccount:password"];
                Default = new Member
                {
                    MemberId = 0,
                    Email = email,
                    CompanyName = "",
                    City = "",
                    Country = "",
                    Password = password,
                };
            }
            return Default;
        }
    }

}
