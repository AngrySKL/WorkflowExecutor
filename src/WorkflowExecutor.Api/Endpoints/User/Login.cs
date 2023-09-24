using FastEndpoints;
using FastEndpoints.Security;
using FluentValidation;

namespace WorkflowExecutor.Api.Endpoints.User
{
    sealed record LoginRequest(string Username, string Password)
    {
        public const string Route = "/User/Login";
    }

    sealed record LoginResponse(string Role, string Token);

    sealed class LoginValidator : Validator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Username cannot be empty!");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty!");
        }
    }

    sealed class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
    {
        private readonly IConfiguration _configuration;

        public LoginEndpoint(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Configure()
        {
            Post(LoginRequest.Route);
            AllowAnonymous();
            Options(x => x.WithTags("UserEndpoints"));
        }

        public override async Task HandleAsync(LoginRequest r, CancellationToken c)
        {
            var role = "";
            if (r.Username == "admin" && r.Password == "pwd@123")
            {
                // var role = someService.GetRoleByUserName(r.Username);
                role = "Admin";
            }
            else if (r.Username == "user" && r.Password == "pwd@123")
            {
                role = "User";
            }
            else
            {
                ThrowError("Invalid credential supplied!");
            }

            var jwtToken = JWTBearer.CreateToken(
                signingKey: _configuration["TokenSigningKey"],
                privileges: u =>
                {
                    u.Roles.Add(role);
                });

            await SendAsync(new LoginResponse(role, jwtToken));
        }
    }
}
