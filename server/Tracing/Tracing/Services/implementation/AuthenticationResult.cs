using Tracing.DataAccess.Models;

namespace Tracing.Services.implementation;

public record AuthenticationResult(
    Owner owner,
    string Token);