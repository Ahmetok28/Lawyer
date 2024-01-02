using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Core.Extensions;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }

    //public string CreateRefreshToken()
    //{
    //    var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);
    //    var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
    //    var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

    //    var refreshToken = new JwtSecurityToken(
    //        issuer: _tokenOptions.Issuer,
    //        audience: _tokenOptions.Audience,
    //        expires: refreshTokenExpiration,
    //        notBefore: DateTime.UtcNow,
    //        signingCredentials: signingCredentials
    //    );

    //    var refreshTokenHandler = new JwtSecurityTokenHandler();
    //    return refreshTokenHandler.WriteToken(refreshToken);
    //}

    //public bool ValidateRefreshToken(string refreshToken)
    //{
    //    var refreshTokenHandler = new JwtSecurityTokenHandler();

    //    try
    //    {
    //        var tokenValidationParameters = new TokenValidationParameters
    //        {
    //            ValidateIssuer = true,
    //            ValidateAudience = true,
    //            ValidateLifetime = true,
    //            ValidateIssuerSigningKey = true,
    //            ValidIssuer = _tokenOptions.Issuer,
    //            ValidAudience = _tokenOptions.Audience,
    //            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey),
    //            ClockSkew = TimeSpan.Zero
    //        };

    //        refreshTokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out var validatedToken);
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
}
