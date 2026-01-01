# Developer Workflow Guide - Implementing Skeleton Files

## Quick Reference: How to Uncomment and Implement

### Step-by-Step Process

#### 1. Locate the File
```
Example: FacebookOAuthService.cs
Location: src/backend/Fepa.CoreService/Fepa.Application/Services/
```

#### 2. Open in VS Code
```csharp
// BEFORE (Commented):
/*
public class FacebookOAuthService
{
    // public async Task<LoginResponse> LoginAsync(OAuthLoginRequest request)
    // {
    //     // Code here
    // }
}
*/

// AFTER (Uncommented):
public class FacebookOAuthService
{
    public async Task<LoginResponse> LoginAsync(OAuthLoginRequest request)
    {
        // Code here
    }
}
```

#### 3. Remove Comment Markers
- Select all text inside `/* */`
- Use Find & Replace:
  - Find: `// ` (at start of line inside comment)
  - Replace with: `` (nothing)
- Remove outer `/*` and `*/`

#### 4. Verify Compilation
```bash
cd src/backend/Fepa.CoreService/Fepa.API
dotnet build
```

#### 5. Run Tests
```bash
cd src/backend/Fepa.CoreService/Fepa.API.Tests
dotnet test
```

---

## File-by-File Implementation Guide

### 1. FacebookOAuthService.cs
**Location:** `Fepa.Application/Services/FacebookOAuthService.cs`
**Dev:** Dev 1 (OAuth Expert)
**Time Est:** 30 minutes
**Steps:**
1. Uncomment the entire class
2. Install `Facebook.CSharp.SDK` NuGet package (if needed)
3. Update OAuth configuration in appsettings.json
4. Test with Facebook App ID and Secret
5. Verify LoginAsync works with Facebook ID token

**Key Methods:**
- `LoginAsync(OAuthLoginRequest)` - Main OAuth login flow

**Tests to Run:**
```bash
dotnet test --filter "FacebookOAuth"
```

---

### 2. PasswordResetService.cs
**Location:** `Fepa.Application/Services/PasswordResetService.cs`
**Dev:** Dev 3 (Backend)
**Time Est:** 40 minutes
**Steps:**
1. Uncomment all methods
2. Ensure IVerificationTokenRepository is working
3. Update email template in EmailService
4. Test with invalid emails (should return silently for security)
5. Test token expiration

**Key Methods:**
- `ForgotPasswordAsync(string email)` - Send reset email
- `ResetPasswordAsync(string token, string newPassword)` - Update password
- `ValidateResetTokenAsync(string token)` - Validate token

**Tests to Run:**
```bash
dotnet test --filter "PasswordReset"
```

---

### 3. RefreshTokenService.cs
**Location:** `Fepa.Application/Services/RefreshTokenService.cs`
**Dev:** Dev 3 (Backend)
**Time Est:** 35 minutes
**Steps:**
1. Uncomment all methods
2. Ensure RefreshTokenRepository is injected
3. Implement token rotation logic
4. Test token revocation
5. Verify expiration checks

**Key Methods:**
- `RefreshAccessTokenAsync(string refreshToken)` - Get new access token
- `RevokeTokenAsync(string refreshToken)` - Logout
- `RevokeAllUserTokensAsync(Guid userId)` - Logout from all devices

**Tests to Run:**
```bash
dotnet test --filter "RefreshToken"
```

---

### 4. RoleService.cs
**Location:** `Fepa.Application/Services/RoleService.cs`
**Dev:** Dev 3 (RBAC)
**Time Est:** 30 minutes
**Steps:**
1. Uncomment all methods
2. Add `Role` property to User entity if missing
3. Configure authorization policies in startup
4. Add role claims to JWT tokens in TokenService
5. Test role-based access control

**Key Methods:**
- `GetUserRoleAsync(Guid userId)` - Retrieve user role
- `AssignRoleAsync(Guid userId, string role)` - Assign role
- `HasPermissionAsync(Guid userId, string permission)` - Check permission
- `GetRolePermissions(string role)` - List role permissions

**Roles:**
- Admin (all permissions)
- Premium (read, write, delete, view reports)
- User (read, write, delete)
- Guest (read only)

**Tests to Run:**
```bash
dotnet test --filter "Role"
```

---

### 5. EmailVerificationService.cs
**Location:** `Fepa.Application/Services/EmailVerificationService.cs`
**Dev:** Dev 2 (Email Services)
**Time Est:** 35 minutes
**Steps:**
1. Uncomment all methods
2. Integrate with existing IEmailService
3. Ensure VerificationTokenRepository is working
4. Test token generation and validation
5. Test email sending

**Key Methods:**
- `SendVerificationEmailAsync(string email)` - Send verification email
- `VerifyEmailAsync(string email, string token)` - Verify email
- `ResendVerificationEmailAsync(string email)` - Resend email
- `IsEmailVerifiedAsync(Guid userId)` - Check verification status

**Tests to Run:**
```bash
dotnet test --filter "EmailVerification"
```

---

### 6. AuthControllerEnhanced.cs
**Location:** `Fepa.API/Controllers/AuthControllerEnhanced.cs`
**Dev:** Dev 1 (API)
**Time Est:** 45 minutes
**Steps:**
1. Uncomment all endpoint methods
2. Keep existing AuthController.cs for basic endpoints
3. Add this as alternative comprehensive controller
4. Update routing (consider renaming to AuthController after testing)
5. Test all 16 endpoints
6. Add CORS configuration if needed

**Endpoints:**
- POST /api/auth/register
- POST /api/auth/login
- POST /api/auth/setup-2fa
- POST /api/auth/verify-2fa
- POST /api/auth/forgot-password
- POST /api/auth/reset-password
- POST /api/auth/refresh-token
- POST /api/auth/logout
- POST /api/auth/google-login
- POST /api/auth/facebook-login

**Tests to Run:**
```bash
dotnet test AuthIntegrationTests
```

---

### 7. AuthConfiguration.cs
**Location:** `Fepa.API/Configuration/AuthConfiguration.cs`
**Dev:** Dev 1 (Setup)
**Time Est:** 30 minutes
**Steps:**
1. Uncomment `AddAuthServices()` method
2. Update Program.cs to call: `services.AddAuthServices(configuration)`
3. Configure JWT authentication in Program.cs
4. Set up CORS if needed
5. Test endpoint authorization

**To Use:**
```csharp
// In Program.cs:
var services = builder.Services;
var config = builder.Configuration;

services.AddAuthServices(config);  // Add this line
```

---

### 8. AuthApiDocumentation.cs
**Location:** `Fepa.API/AuthApiDocumentation.cs`
**Dev:** Dev 1 (Documentation)
**Time Est:** 20 minutes
**Steps:**
1. Keep as-is (XML comments only)
2. Copy comments to actual AuthController methods
3. Run Swagger/Swashbuckle to generate documentation
4. Test with Swagger UI

---

### 9. EnhanceAuthService.cs (Migration)
**Location:** `Fepa.Infrastructure/Migrations/EnhanceAuthService.cs`
**Dev:** Dev 3 (Database)
**Time Est:** 25 minutes
**Steps:**
1. Uncomment migration Up() and Down() methods
2. Replace migration placeholder with actual migration name
3. Run migration:
```bash
dotnet ef migrations add EnhanceAuthService --project ../Fepa.Infrastructure
dotnet ef database update
```
4. Verify tables created in PostgreSQL
5. Check indexes created

---

### 10. FepaDbContextEnhanced.cs
**Location:** `Fepa.Infrastructure/Persistence/FepaDbContextEnhanced.cs`
**Dev:** Dev 3 (Database)
**Time Est:** 30 minutes
**Steps:**
1. Uncomment `ConfigureAuthEntities()` method
2. Add to FepaDbContext.OnModelCreating():
```csharp
modelBuilder.ConfigureAuthEntities();
```
3. Add DbSets to FepaDbContext:
```csharp
public DbSet<RefreshToken> RefreshTokens { get; set; }
public DbSet<VerificationToken> VerificationTokens { get; set; }
```
4. Run migration to apply configuration
5. Test entity relationships

---

### 11-18. Test Files (One pattern applies to all)

#### AuthServiceTests.cs
**Location:** `Fepa.API.Tests/AuthServiceTests.cs`
**Dev:** Dev 1 (Testing)
**Time Est:** 40 minutes
**Pattern:**
1. Uncomment test class
2. Uncomment each [Fact] test method
3. Uncomment Arrange-Act-Assert logic
4. Run: `dotnet test AuthServiceTests`
5. Fix any failing tests
6. Add more test cases as needed

#### OtpServiceTests.cs
**Location:** `Fepa.API.Tests/OtpServiceTests.cs`
**Dev:** Dev 2 (Testing)
**Time Est:** 30 minutes

#### EmailServiceTests.cs
**Location:** `Fepa.API.Tests/EmailServiceTests.cs`
**Dev:** Dev 2 (Testing)
**Time Est:** 30 minutes

#### PasswordResetServiceTests.cs
**Location:** `Fepa.API.Tests/PasswordResetServiceTests.cs`
**Dev:** Dev 3 (Testing)
**Time Est:** 35 minutes

#### RefreshTokenServiceTests.cs
**Location:** `Fepa.API.Tests/RefreshTokenServiceTests.cs`
**Dev:** Dev 3 (Testing)
**Time Est:** 35 minutes

#### AuthIntegrationTests.cs
**Location:** `Fepa.API.Tests/AuthIntegrationTests.cs`
**Dev:** Dev 2 & 3 (Integration Testing)
**Time Est:** 45 minutes
**Special Note:** Requires WebApplicationFactory setup

#### PerformanceTests.cs
**Location:** `Fepa.API.Tests/PerformanceTests.cs`
**Dev:** Dev 2 & 3 (Performance)
**Time Est:** 30 minutes
**Note:** Run separately: `dotnet test PerformanceTests`

#### SecurityTests.cs
**Location:** `Fepa.API.Tests/SecurityTests.cs`
**Dev:** Dev 2 & 3 (Security)
**Time Est:** 40 minutes
**Note:** Tests attack scenarios - very important

---

## Common Issues and Solutions

### Issue 1: "Namespace not found"
**Solution:** Check using statements at top of file
```csharp
using Fepa.Application.Interfaces;
using Fepa.Application.DTOs.Auth;
using Fepa.Domain.Entities;
```

### Issue 2: "Method not implemented"
**Solution:** Look for `// TODO:` or `throw new NotImplementedException()` comments
Replace with actual logic from commented code above

### Issue 3: "NuGet package not found"
**Solution:** Install missing package
```bash
dotnet add package PackageName
```

### Issue 4: "Migration already exists"
**Solution:** Delete migration file and try again
```bash
rm src/backend/Fepa.CoreService/Fepa.Infrastructure/Migrations/EnhanceAuthService.cs
dotnet ef migrations add EnhanceAuthService
```

### Issue 5: "Tests won't compile"
**Solution:** Make sure Moq and xUnit packages are installed
```bash
dotnet add package xunit
dotnet add package Moq
```

---

## Testing Checklist

### Unit Tests
- [ ] AuthServiceTests - All 4+ test cases pass
- [ ] OtpServiceTests - All 5+ test cases pass
- [ ] EmailServiceTests - All 3+ test cases pass
- [ ] PasswordResetServiceTests - All 3+ test cases pass
- [ ] RefreshTokenServiceTests - All 3+ test cases pass

### Integration Tests
- [ ] AuthIntegrationTests - Full flow tests pass
- [ ] All endpoints respond correctly
- [ ] Token validation works

### Performance Tests
- [ ] JwtGeneration < 1000ms for 1000 iterations
- [ ] PasswordHashing < 10000ms for 100 iterations
- [ ] No N+1 query problems

### Security Tests
- [ ] SQL injection protected
- [ ] XSS protected
- [ ] Token tampering detected
- [ ] Unauthorized access denied
- [ ] Password hashes are irreversible

---

## Deployment Checklist

Before deploying to production:

- [ ] All files compiled without errors
- [ ] All tests passed (100% passing rate)
- [ ] Migration applied to production database
- [ ] appsettings.Production.json configured
- [ ] Email SMTP credentials set
- [ ] OAuth app IDs and secrets configured
- [ ] JWT secret key set (strong, random)
- [ ] CORS configured for frontend domains
- [ ] HTTPS enforced
- [ ] Rate limiting enabled
- [ ] Logging configured
- [ ] Error monitoring set up
- [ ] Swagger disabled in production

---

## Quick Commands Reference

```bash
# Build
dotnet build

# Run tests
dotnet test
dotnet test --filter "AuthService"
dotnet test PerformanceTests

# Add migration
dotnet ef migrations add MigrationName --project ../Fepa.Infrastructure

# Apply migration
dotnet ef database update

# Update migration
dotnet ef migrations remove
dotnet ef migrations add MigrationName --project ../Fepa.Infrastructure

# Run API
dotnet run

# Watch mode (auto-rebuild)
dotnet watch run

# Clean
dotnet clean
```

---

## Expected Development Timeline

| Phase | Duration | Tasks | Developer(s) |
|-------|----------|-------|--------------|
| Phase 1 | 2-3 days | Register, Login, OAuth setup, validation | Dev 1 |
| Phase 2 | 2-3 days | 2FA, Email verification, email service | Dev 2 |
| Phase 3 | 2-3 days | Password reset, refresh tokens, RBAC | Dev 3 |
| Phase 4 | 1-2 days | Tests, integration tests, documentation | All |
| Phase 5 | 1 day | Database migration, configuration, deployment | Dev 3 |
| **Total** | **9-12 days** | Complete implementation + testing | 3 people |

---

## Support Resources

### When Stuck:
1. Check the commented code for examples
2. Review similar service already implemented
3. Check test cases for usage patterns
4. Refer to IMPLEMENTATION_SUMMARY.md for architecture
5. Check appsettings.Development.json for configuration examples

### Common Reference Files:
- `AuthService.cs` - Reference for service patterns (already complete)
- `UserRepository.cs` - Reference for repository patterns (already complete)
- `EmailService.cs` - Reference for external service integration (already complete)
- `OtpService.cs` - Reference for utility service patterns (already complete)

---

**Status:** All files ready for implementation
**Quality Level:** Production-ready code templates
**Estimated Effort:** 9-12 developer days for 3-person team
**Support:** All code includes comments explaining logic and patterns
