namespace Fepa.API
{
    /*
    /// <summary>
    /// Auth API Documentation
    /// 
    /// All Auth endpoints include comprehensive error handling and validation.
    /// </summary>
    public class AuthApiDocumentation
    {
        /// <summary>
        /// POST /api/auth/register
        /// Registers a new user account
        /// 
        /// Request:
        /// {
        ///   "fullName": "John Doe",
        ///   "email": "john@example.com",
        ///   "password": "SecurePass123!"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "message": "Registration successful. Please verify your email.",
        ///   "data": {
        ///     "userId": "guid",
        ///     "email": "john@example.com",
        ///     "emailVerified": false
        ///   }
        /// }
        /// 
        /// Error Codes:
        /// - 400: Validation failed (invalid email, weak password, etc.)
        /// - 409: Email already exists
        /// </summary>

        /// <summary>
        /// POST /api/auth/login
        /// Authenticates user with email and password
        /// 
        /// Request:
        /// {
        ///   "email": "john@example.com",
        ///   "password": "SecurePass123!"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "accessToken": "eyJhbGc...",
        ///   "refreshToken": "base64_refresh_token",
        ///   "expiresIn": 3600,
        ///   "user": { ... },
        ///   "requiresTwoFactor": false
        /// }
        /// 
        /// Error Codes:
        /// - 401: Invalid credentials
        /// - 403: Account locked due to failed attempts
        /// </summary>

        /// <summary>
        /// POST /api/auth/refresh-token
        /// Generates new access token using refresh token
        /// 
        /// Request:
        /// {
        ///   "refreshToken": "base64_refresh_token"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "accessToken": "new_eyJhbGc...",
        ///   "refreshToken": "new_base64_token",
        ///   "expiresIn": 3600
        /// }
        /// 
        /// Error Codes:
        /// - 401: Invalid or expired refresh token
        /// </summary>

        /// <summary>
        /// POST /api/auth/setup-2fa
        /// [Requires Authentication]
        /// Generates TOTP secret and QR code for 2FA setup
        /// 
        /// Response (200):
        /// {
        ///   "secret": "base32_secret",
        ///   "qrCodeUrl": "otpauth://...",
        ///   "backupCodes": ["123456", "234567", ...]
        /// }
        /// </summary>

        /// <summary>
        /// POST /api/auth/verify-2fa
        /// [Requires Authentication]
        /// Verifies TOTP code and enables 2FA
        /// 
        /// Request:
        /// {
        ///   "code": "123456"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "message": "2FA enabled successfully"
        /// }
        /// 
        /// Error Codes:
        /// - 400: Invalid 2FA code
        /// </summary>

        /// <summary>
        /// POST /api/auth/forgot-password
        /// Sends password reset email
        /// 
        /// Request:
        /// {
        ///   "email": "john@example.com"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "message": "Password reset email sent"
        /// }
        /// 
        /// Note: Returns success even if email not found (security)
        /// </summary>

        /// <summary>
        /// POST /api/auth/reset-password
        /// Resets password with token from email
        /// 
        /// Request:
        /// {
        ///   "token": "verification_token_from_email",
        ///   "newPassword": "NewSecurePass123!"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "message": "Password reset successful"
        /// }
        /// 
        /// Error Codes:
        /// - 400: Invalid or expired token
        /// - 400: Password validation failed
        /// </summary>

        /// <summary>
        /// POST /api/auth/google-login
        /// OAuth login with Google ID token
        /// 
        /// Request:
        /// {
        ///   "idToken": "google_id_token"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "accessToken": "...",
        ///   "refreshToken": "...",
        ///   "user": { ... }
        /// }
        /// 
        /// Error Codes:
        /// - 401: Invalid Google token
        /// </summary>

        /// <summary>
        /// POST /api/auth/facebook-login
        /// OAuth login with Facebook access token
        /// 
        /// Request:
        /// {
        ///   "idToken": "facebook_access_token"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "accessToken": "...",
        ///   "refreshToken": "...",
        ///   "user": { ... }
        /// }
        /// 
        /// Error Codes:
        /// - 401: Invalid Facebook token
        /// </summary>

        /// <summary>
        /// POST /api/auth/logout
        /// [Requires Authentication]
        /// Revokes refresh token (user logout)
        /// 
        /// Request:
        /// {
        ///   "refreshToken": "token_to_revoke"
        /// }
        /// 
        /// Response (200):
        /// {
        ///   "message": "Logout successful"
        /// }
        /// </summary>
    }
    */
}
