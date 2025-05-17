using WatchListMovies.Common.Domain;
using WatchListMovies.Common.Domain.Exceptions;
using WatchListMovies.Common.Domain.Utils;
using WatchListMovies.Domain.UserAgg.Enums;

namespace WatchListMovies.Domain.UserAgg
{
    public class User : BaseEntity
    {
        private User()
        {

        }
        public User(string name, string family, string phoneNumber, string email,
            string password, Gender gender)
        {
            Guard(phoneNumber, email);

            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            AvatarName = "avatar.png";
            Tokens = new();
        }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarName { get; set; }
        public Gender Gender { get; set; }
        public List<UserToken> Tokens { get; }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            //if (activeTokenCount == 3)
            //    throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }

        public static User RegisterUser(string phoneNumber, string password)
        {
            return new User("", "", phoneNumber, null, password, Gender.None);
        }

        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));

            Password = newPassword;
        }

        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = "avatar.png";

            AvatarName = imageName;
        }
        public void Edit(string name, string family,
            string phoneNumber, string email, Gender gender)
        {
            Guard(phoneNumber, email);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public string RemoveToken(Guid tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("invalid TokenId");

            Tokens.Remove(token);
            return token.HashJwtToken;
        }

        public void Guard(string phoneNumber, string email)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

            //if (phoneNumber != PhoneNumber)
            //    if (userDomainService.IsPhoneNumberExist(phoneNumber))
            //        throw new InvalidDomainDataException("شماره موبایل تکراری است");

            //if (email != Email)
            //    if (userDomainService.IsEmailExist(email))
            //        throw new InvalidDomainDataException("ایمیل تکراری است");
        }

    }
}
