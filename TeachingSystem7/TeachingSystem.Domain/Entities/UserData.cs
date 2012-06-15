using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TeachingSystem.Domain.Entities
{
    public class UserData
    {
        //对应studentData表中的各个字段
        public  string Account { get;set;}
        public  string Role { get; set; }
        public  string Name { get; set; }
        public  string NickName { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public  string Sex { get; set; }
        public  string Major { get; set; }
        public  string College { get; set; }

        public UserData(string account, string role,string name, string nickName,string password,
            string sex, string major, string college, string email)
        {
            Account = account;
            Role = role;
            Name = name;
            Password = password;
            Email = email;
            Sex = sex;
            Major = major;
            College = college;

            if (!String.IsNullOrEmpty(nickName))
                NickName = nickName;
            else
                NickName = "";
        }

        public UserData() { }
    }
}
