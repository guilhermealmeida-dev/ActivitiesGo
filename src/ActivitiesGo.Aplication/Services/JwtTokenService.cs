using System;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Domain.Entities;
using ActivitiesGo.Shared.Config;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;

namespace ActivitiesGo.Aplication.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly string _secret;
    public JwtTokenService(IOptions<AppSettings> options)
    {        
        _secret = options.Value.JwtKey;
    }

    public string GenerateToken(User user)
    {
        var token = JwtBuilder.Create().WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(_secret)
            .AddClaim("sub", user.Id.ToString())
            .AddClaim("email", user.Email)
            .AddClaim("name", user.Name)
            .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds())
            .Encode();

        return token;
    }

    public IDictionary<string, object> ValidateToken(string token)
    {
        var payload = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(_secret)
            .MustVerifySignature()
            .Decode<IDictionary<string, object>>(token);

        return payload;
    }
}
