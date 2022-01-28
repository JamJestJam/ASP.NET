using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Extends {
    public class PLIdentityErrors : IdentityErrorDescriber {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Nieznany błąd." }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Obiekt został zmodyfikowany." }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Niepoprawne hasło." }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Niepoprawny token." }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Użytkownik o tym loginie już istnieje." }; }
        public override IdentityError InvalidUserName(String userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"Nazwa użytkownika: '{userName}' jest niepoprawna. Nazwa użytkownika może się składać tylko z liter i cyfr." }; }
        public override IdentityError InvalidEmail(String email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Podany email: '{email}' jest niepoprawny." }; }
        public override IdentityError DuplicateUserName(String userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Nazwa użytkonika: '{userName}' jest już zajęta." }; }
        public override IdentityError DuplicateEmail(String email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Email: '{email}' jest niepoprawny." }; }
        public override IdentityError PasswordTooShort(Int32 length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Hasło musi zawierać przynajmniej {length} znaków." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = $"Hasło musi zawierać conajmniej jeden znak specjalny." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = $"Hasło musi zawierać przynajmniej jedną cyfre." }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = $"Hasło musi zawierać przynajmniej jedną małą literę." }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = $"Hasło musi zawierać przynajmniej jedną dużą literę." }; }
    }
}
