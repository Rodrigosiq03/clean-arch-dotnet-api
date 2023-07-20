using System.Text.RegularExpressions;
using Domain.Enums;
using Domain.Errors;

namespace Domain.Entities;

public class User
{
        public string Ra { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public State State { get; private set; }
    
        private const int RaLength = 10;
        private const int NameLength = 2;
        private const string PatternEmail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        
        public User(string ra, string name, string email, State state)
        {
            if (!ValidateRa(ra))
            {
                throw new EntityError("this.Ra");
            }
            Ra = ra;
    
            if (!ValidateName(name))
            {
                throw new EntityError("this.Name");
            }
            Name = name;
    
            if (!ValidateEmail(email))
            {
                throw new EntityError("this.Email");
            }
            Email = email;
    
            if (!ValidateState(state))
            {
                throw new EntityError("this.State");
            }
            State = state;
    
        }
    
        public static bool ValidateRa(string ra)
        {
            if (ra is null)
            {
                return false;
            }
    
            if (ra.Length != RaLength)
            {
                return false;
            }
    
            if (ra.GetType() != typeof(string))
            {
                return false;
            }
            
            return true;
        }
    
        public static bool ValidateName(string name)
        {
            if (name is null)
            {
                return false;
            }    
            
            if (name.Length < NameLength)
            {
                return false;
            }
    
            if (name.GetType() != typeof(string))
            {
                return false;
            }
    
            return true;
        }
    
        public static bool ValidateEmail(string email)
        {
            if (email is null)
            {
                return false;
            }
    
            if (!Regex.IsMatch(email, PatternEmail))
            {
                return false;
            }
    
            return true;
        }
    
        public static bool ValidateState(State state)
        {
            
            if (!Enum.IsDefined(typeof(State), state))
            {
                return false;
            }
    
            return true;
        } 
}