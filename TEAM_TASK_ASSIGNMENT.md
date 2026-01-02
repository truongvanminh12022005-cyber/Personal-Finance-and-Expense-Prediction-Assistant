# 👥 PHÂN CHIA TASK CHI TIẾT CHO TEAM FEPA

**Project:** FEPA v1.0 | **Start Date:** January 3, 2026 | **Duration:** 6 weeks

---

## 👨‍💼 THÔNG TIN TEAM

| Vị Trí | Developer | Chuyên Môn | Số Giờ/Tuần |
|--------|-----------|-----------|------------|
| **Dev Lead 1** | [Tên] | Backend, OAuth, Security | 40h |
| **Dev Lead 2** | [Tên] | Mobile (React Native) | 40h |
| **Backend Dev** | [Tên] | Database, APIs, Repositories | 40h |
| **Fullstack Dev** | [Tên] | Web Admin, AI/ML, DevOps, Docs | 40h |

---

## 🎯 PHASE 1: TUẦN 1-2 (Backend Foundation + Mobile UI)

### **✏️ DEV 1 - OAuth & Core Authentication**

**Total Hours:** 30h | **Start:** Jan 3 | **End:** Jan 10

#### Task 1.1: Google OAuth Service Implementation
- **Assignee:** Dev 1
- **Start:** Jan 3 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Edit:**
  - `src/backend/Fepa.CoreService/Fepa.Application/Services/GoogleOAuthService.cs`
  - `src/backend/Fepa.CoreService/Fepa.API/appsettings.Development.json`

**Checklist:**
- [ ] Uncomment GoogleOAuthService class
- [ ] Implement `LoginAsync(OAuthLoginRequest request)` method
- [ ] Handle Google ID token validation
- [ ] Auto-create user on first login
- [ ] Auto-link account on subsequent login
- [ ] Add error handling & logging
- [ ] Write unit tests
- [ ] Test with real Google credentials

**Acceptance Criteria:**
```
✅ POST /api/oauth/google-login accepts valid Google ID token
✅ User created automatically with email from Google profile
✅ Returns valid JWT token + refresh token
✅ Existing user logged in without creating duplicate
✅ All errors properly logged & handled
✅ Unit tests pass (>80% coverage)
```

**Git Commit Message:**
```
feat(oauth): Implement Google OAuth login

- Implement GoogleOAuthService with token validation
- Auto-create user from Google profile data
- Link existing users on subsequent login
- Add error handling & logging
```

**Dependencies:** None
**Blockers:** Google OAuth credentials needed
**Notes:** Get Google Client ID from https://console.cloud.google.com

---

#### Task 1.2: Facebook OAuth Service Implementation
- **Assignee:** Dev 1
- **Start:** Jan 6 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Edit:**
  - `src/backend/Fepa.CoreService/Fepa.Application/Services/FacebookOAuthService.cs`

**Checklist:**
- [ ] Uncomment FacebookOAuthService class
- [ ] Implement `LoginAsync(OAuthLoginRequest request)` method
- [ ] Make API call to Facebook to validate token
- [ ] Extract user data from Facebook API
- [ ] Handle user creation/linking
- [ ] Error handling for invalid tokens
- [ ] Unit tests
- [ ] Integration tests

**Acceptance Criteria:**
```
✅ POST /api/oauth/facebook-login validates Facebook token
✅ User data fetched from Facebook API
✅ Auto-create/link user account
✅ Returns valid JWT + refresh tokens
✅ All error scenarios handled
✅ Tests pass
```

**Git Commit Message:**
```
feat(oauth): Implement Facebook OAuth login

- Implement FacebookOAuthService with Facebook API integration
- Validate tokens via Facebook Graph API
- Auto-create/link user accounts
- Full error handling
```

**Dependencies:** Task 1.1 (Google OAuth pattern established)
**Blockers:** Facebook App credentials needed
**Notes:** Get credentials from https://developers.facebook.com/apps

---

#### Task 1.3: OAuth Controller & Endpoints
- **Assignee:** Dev 1
- **Start:** Jan 7 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/backend/Fepa.CoreService/Fepa.API/Controllers/OAuthController.cs`

**Checklist:**
- [ ] Create OAuthController class
- [ ] Implement POST `/api/oauth/google-login` endpoint
- [ ] Implement POST `/api/oauth/facebook-login` endpoint
- [ ] Add request validation
- [ ] Add response formatting
- [ ] Swagger/OpenAPI documentation
- [ ] Integration tests for endpoints
- [ ] Load testing

**Acceptance Criteria:**
```
✅ Both endpoints return 200 with valid tokens
✅ Invalid tokens return 401
✅ Missing credentials return 400
✅ Rate limiting applied
✅ Swagger docs updated
✅ Integration tests pass
```

**Git Commit Message:**
```
feat(api): Add OAuth endpoints

- Create OAuthController with Google & Facebook endpoints
- Add request validation & response formatting
- Add Swagger documentation
- Integration tests included
```

**Dependencies:** Tasks 1.1, 1.2
**Blockers:** None
**Notes:** Test both endpoints with Postman before moving forward

---

#### Task 1.4: OAuth Testing & Integration
- **Assignee:** Dev 1
- **Start:** Jan 8 | **Duration:** 1 day (6h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files:**
  - `src/backend/Fepa.CoreService/Fepa.API.Tests/OAuthServiceTests.cs`
  - `src/backend/Fepa.CoreService/Fepa.API.Tests/OAuthIntegrationTests.cs`

**Checklist:**
- [ ] Write unit tests for GoogleOAuthService
- [ ] Write unit tests for FacebookOAuthService
- [ ] Write integration tests for OAuth flow
- [ ] Test error scenarios
- [ ] Mock external APIs
- [ ] Achieve >85% code coverage
- [ ] Document test cases
- [ ] Fix any bugs found

**Acceptance Criteria:**
```
✅ All unit tests pass
✅ All integration tests pass
✅ Code coverage >85%
✅ Error scenarios tested
✅ Documentation complete
```

**Git Commit Message:**
```
test(oauth): Add comprehensive OAuth tests

- Unit tests for Google & Facebook services
- Integration tests for full OAuth flow
- Error scenario testing
- >85% code coverage achieved
```

**Dependencies:** Tasks 1.1, 1.2, 1.3
**Blockers:** None
**Notes:** Use xUnit + Moq for testing

---

### **📱 DEV 2 - Mobile App Foundation**

**Total Hours:** 32h | **Start:** Jan 3 | **End:** Jan 10

#### Task 2.1: Mobile Project Structure & Navigation
- **Assignee:** Dev 2
- **Start:** Jan 3 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/clients/mobile-app/src/navigation/BottomTabNavigator.tsx`
  - `src/clients/mobile-app/src/navigation/AuthStackNavigator.tsx`
  - `src/clients/mobile-app/src/navigation/RootNavigator.tsx`

**Folder Structure to Create:**
```
src/
├── screens/
│   ├── Auth/
│   ├── Home/
│   ├── Expenses/
│   ├── Budget/
│   ├── Settings/
│   └── Profile/
├── components/
├── navigation/
├── services/
├── redux/
├── db/
├── utils/
└── hooks/
```

**Checklist:**
- [ ] Create folder structure
- [ ] Install React Navigation (@react-navigation/native, etc.)
- [ ] Setup BottomTabNavigator (5 tabs)
- [ ] Setup AuthStackNavigator
- [ ] Setup RootNavigator with auth state
- [ ] Configure navigation props
- [ ] Test navigation flow
- [ ] TypeScript setup complete

**Acceptance Criteria:**
```
✅ Navigation structure complete
✅ All navigation paths working
✅ Auth/App stacks switching correctly
✅ TypeScript no errors
✅ No console warnings
```

**Git Commit Message:**
```
feat(mobile): Setup project structure and navigation

- Create folder structure for screens, components, services
- Implement BottomTabNavigator with 5 tabs
- Implement AuthStackNavigator
- Configure RootNavigator with auth flow
```

**Dependencies:** None
**Blockers:** None
**Notes:** Use TypeScript for type safety

---

#### Task 2.2: Authentication Screens (Login & Register)
- **Assignee:** Dev 2
- **Start:** Jan 4 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/clients/mobile-app/src/screens/Auth/LoginScreen.tsx`
  - `src/clients/mobile-app/src/screens/Auth/RegisterScreen.tsx`
  - `src/clients/mobile-app/src/screens/Auth/ForgotPasswordScreen.tsx`

**Checklist:**
- [ ] Create LoginScreen with email/password input
- [ ] Create RegisterScreen with form validation
- [ ] Create ForgotPasswordScreen
- [ ] Add Google OAuth button
- [ ] Add Facebook OAuth button
- [ ] Form validation (email, password strength)
- [ ] Error message display
- [ ] Loading states
- [ ] Mock data for testing
- [ ] Responsive design (all screen sizes)

**Acceptance Criteria:**
```
✅ All forms render correctly
✅ Form validation working
✅ OAuth buttons present (not functional yet)
✅ Error messages display properly
✅ Loading indicators show
✅ Responsive on all devices
✅ No TypeScript errors
```

**Git Commit Message:**
```
feat(mobile): Add authentication screens

- Create LoginScreen with email/password
- Create RegisterScreen with validation
- Create ForgotPasswordScreen
- Add OAuth buttons (UI only)
- Responsive design for all devices
```

**Dependencies:** Task 2.1
**Blockers:** None
**Notes:** Use React Hook Form + Yup for validation

---

#### Task 2.3: Dashboard & Home Screen
- **Assignee:** Dev 2
- **Start:** Jan 5 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files to Create:**
  - `src/clients/mobile-app/src/screens/Home/HomeScreen.tsx`
  - `src/clients/mobile-app/src/components/SummaryCard.tsx`
  - `src/clients/mobile-app/src/components/QuickActionButton.tsx`

**Checklist:**
- [ ] Create HomeScreen layout
- [ ] Add summary cards (Total Expense, Budget, Savings)
- [ ] Add quick action buttons (Add Expense, View All)
- [ ] Add recent expenses list
- [ ] Mock data integration
- [ ] Responsive design
- [ ] Loading skeleton screens
- [ ] Pull-to-refresh (prep)

**Acceptance Criteria:**
```
✅ Dashboard renders with all sections
✅ Summary cards display correctly
✅ Quick actions visible
✅ Mock data populates screen
✅ Responsive on all devices
✅ Smooth animations
✅ No TypeScript errors
```

**Git Commit Message:**
```
feat(mobile): Create dashboard/home screen

- Create HomeScreen with summary cards
- Add quick action buttons
- Display recent expenses
- Mock data integration
- Responsive design with animations
```

**Dependencies:** Task 2.1
**Blockers:** None
**Notes:** Use reusable components for summary cards

---

### **🔧 DEV 3 - Backend Expense APIs**

**Total Hours:** 40h | **Start:** Jan 3 | **End:** Jan 10

#### Task 3.1: Expense Entity & Database Schema
- **Assignee:** Dev 3
- **Start:** Jan 3 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/backend/Fepa.CoreService/Fepa.Domain/Entities/Expense.cs`
  - `src/backend/Fepa.CoreService/Fepa.Domain/Entities/Category.cs`
  - Database migration files

**Checklist:**
- [ ] Create Expense entity with all properties
  - Id, UserId, Description, Amount, Currency
  - Category, Date, Tags, Notes, etc.
- [ ] Create Category entity
- [ ] Add relationships (User → Expenses)
- [ ] Add data validation attributes
- [ ] Create DbSet properties in DbContext
- [ ] Create database migrations
- [ ] Run migrations on PostgreSQL
- [ ] Test schema integrity

**Acceptance Criteria:**
```
✅ Entities defined with proper relationships
✅ All properties have validation attributes
✅ Migrations run without errors
✅ Database tables created correctly
✅ Foreign keys established
✅ Indexes on frequently queried columns
```

**Git Commit Message:**
```
feat(db): Add Expense and Category entities

- Create Expense entity with all required properties
- Create Category entity for expense classification
- Setup foreign keys to User entity
- Create and run database migrations
- Add data validation
```

**Dependencies:** None
**Blockers:** PostgreSQL running
**Notes:** Use Entity Framework Core conventions

---

#### Task 3.2: Expense Repository & Interfaces
- **Assignee:** Dev 3
- **Start:** Jan 4 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/backend/Fepa.CoreService/Fepa.Application/Interfaces/IExpenseRepository.cs`
  - `src/backend/Fepa.CoreService/Fepa.Infrastructure/Repositories/ExpenseRepository.cs`

**Checklist:**
- [ ] Create IExpenseRepository interface
  - CreateAsync, GetByIdAsync, GetAllAsync
  - GetByUserIdAsync, GetByDateRangeAsync
  - UpdateAsync, DeleteAsync, GetMonthlyAsync
- [ ] Create ExpenseRepository implementation
- [ ] Add filtering & pagination support
- [ ] Add query optimization (include related data)
- [ ] Unit tests for repository
- [ ] Performance testing

**Acceptance Criteria:**
```
✅ All CRUD operations work
✅ Filtering by user, date range working
✅ Pagination implemented
✅ Query performance acceptable (<500ms)
✅ Unit tests pass
✅ Error handling complete
```

**Git Commit Message:**
```
feat(repo): Add ExpenseRepository

- Create IExpenseRepository interface
- Implement ExpenseRepository with CRUD operations
- Add filtering & pagination
- Add query optimization
- Unit tests included
```

**Dependencies:** Task 3.1
**Blockers:** None
**Notes:** Use async/await pattern

---

#### Task 3.3: Expense DTOs & Validators
- **Assignee:** Dev 3
- **Start:** Jan 5 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files to Create:**
  - `src/backend/Fepa.CoreService/Fepa.Application/DTOs/Expense/`
    - CreateExpenseDTO.cs
    - UpdateExpenseDTO.cs
    - ExpenseResponseDTO.cs
  - Validators for each DTO

**Checklist:**
- [ ] Create CreateExpenseDTO with required fields
- [ ] Create UpdateExpenseDTO
- [ ] Create ExpenseResponseDTO with all fields
- [ ] Create validators using FluentValidation
- [ ] Validate amount (not negative)
- [ ] Validate date (not future)
- [ ] Validate category exists
- [ ] Test all validators

**Acceptance Criteria:**
```
✅ All DTOs created with proper mapping
✅ Validators enforce business rules
✅ Invalid data rejected with clear messages
✅ Tests pass
✅ No validation gaps
```

**Git Commit Message:**
```
feat(dto): Add Expense DTOs and validators

- Create CreateExpenseDTO, UpdateExpenseDTO, ExpenseResponseDTO
- Implement FluentValidation validators
- Add business rule validation
- Complete error message mapping
```

**Dependencies:** Task 3.1
**Blockers:** None
**Notes:** Follow existing DTO patterns

---

#### Task 3.4: Expense APIs (CRUD + Analytics)
- **Assignee:** Dev 3
- **Start:** Jan 6 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/backend/Fepa.CoreService/Fepa.API/Controllers/ExpenseController.cs`

**Endpoints to Implement:**
1. `POST /api/expenses` - Create expense
2. `GET /api/expenses` - List expenses (with filters)
3. `GET /api/expenses/{id}` - Get expense detail
4. `PUT /api/expenses/{id}` - Update expense
5. `DELETE /api/expenses/{id}` - Delete expense
6. `GET /api/expenses/analytics/monthly` - Monthly summary
7. `GET /api/expenses/analytics/category` - Category breakdown
8. `GET /api/expenses/analytics/trend` - Spending trend

**Checklist:**
- [ ] Implement all 8 endpoints
- [ ] Add authentication checks (user can only access own)
- [ ] Add pagination for list endpoints
- [ ] Add filtering (date range, category, etc.)
- [ ] Add sorting options
- [ ] Add Swagger documentation for each endpoint
- [ ] Error handling for all scenarios
- [ ] Unit tests for all endpoints
- [ ] Integration tests

**Acceptance Criteria:**
```
✅ All endpoints return correct status codes
✅ Authentication enforced (user isolation)
✅ Pagination working
✅ Filtering working
✅ Analytics accurate
✅ Swagger docs complete
✅ All tests pass (>90% coverage)
```

**Git Commit Message:**
```
feat(api): Add Expense CRUD and Analytics endpoints

- Implement 8 expense endpoints (CRUD + analytics)
- Add user authentication checks
- Add pagination & filtering
- Add Swagger documentation
- Comprehensive test coverage (>90%)
```

**Dependencies:** Tasks 3.1, 3.2, 3.3
**Blockers:** Dev 1 (OAuth should be done for auth integration)
**Notes:** Ensure proper authorization (users can only access their expenses)

---

### **💼 DEV 4 - Web Admin Setup & Review**

**Total Hours:** 20h | **Start:** Jan 3 | **End:** Jan 10

#### Task 4.1: Backend Integration Testing
- **Assignee:** Dev 4
- **Start:** Jan 3 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files:**
  - `src/backend/Fepa.CoreService/Fepa.API/Fepa.API.http`

**Checklist:**
- [ ] Test all existing endpoints with Fepa.API.http
- [ ] Verify OAuth services working
- [ ] Verify expense endpoints working
- [ ] Test with valid/invalid data
- [ ] Document API usage
- [ ] Update Swagger docs
- [ ] Identify any bugs/issues
- [ ] Create API test suite

**Acceptance Criteria:**
```
✅ All endpoints tested
✅ Documentation updated
✅ No blocking bugs
✅ API behavior correct
```

**Git Commit Message:**
```
test(api): Comprehensive backend testing

- Test all OAuth endpoints
- Test all expense endpoints
- Update API documentation
- Document test results
```

**Dependencies:** Tasks 1, 3 (OAuth & Expense APIs)
**Blockers:** None
**Notes:** Use Fepa.API.http file for testing

---

#### Task 4.2: Web Admin - User Management Structure
- **Assignee:** Dev 4
- **Start:** Jan 5 | **Duration:** 1.5 days (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files to Create:**
  - `src/clients/web-admin/src/pages/Users/UserList.jsx`
  - `src/clients/web-admin/src/pages/Users/UserDetail.jsx`
  - `src/clients/web-admin/src/components/UserTable.jsx`

**Checklist:**
- [ ] Create User list page with DataTable
- [ ] Create User detail/edit page
- [ ] Add user search functionality
- [ ] Add user status filter
- [ ] Add pagination
- [ ] Connect to user API
- [ ] Mock data while backend integration
- [ ] Responsive design

**Acceptance Criteria:**
```
✅ User list renders
✅ Mock data displays
✅ Search/filter UI ready
✅ Responsive layout
✅ Navigation working
```

**Git Commit Message:**
```
feat(admin): Add user management pages

- Create user list page with DataTable
- Create user detail/edit page
- Add search & filter UI
- Mock data integration
- Responsive Ant Design layout
```

**Dependencies:** None (using mock data)
**Blockers:** None
**Notes:** Use Ant Design components

---

---

## 🎯 PHASE 2: TUẦN 2-3 (Mobile Integration + Web Admin)

### **📱 DEV 2 - Mobile API Integration**

**Total Hours:** 40h | **Start:** Jan 11 | **End:** Jan 24

#### Task 5.1: API Service Layer
- **Assignee:** Dev 2
- **Start:** Jan 11 | **Duration:** 1 day (8h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/clients/mobile-app/src/services/api/axiosClient.ts`
  - `src/clients/mobile-app/src/services/ExpenseService.ts`
  - `src/clients/mobile-app/src/services/AuthService.ts`

**Checklist:**
- [ ] Setup axios client with interceptors
- [ ] Add authentication header
- [ ] Add error handling
- [ ] Create ExpenseService methods
- [ ] Create AuthService methods
- [ ] Add retry logic
- [ ] Add request/response logging
- [ ] Test with actual backend

**Acceptance Criteria:**
```
✅ Axios client configured
✅ Interceptors working
✅ Auth headers added
✅ Error handling working
✅ Services callable
```

**Git Commit Message:**
```
feat(mobile): Add API service layer

- Setup axios client with interceptors
- Create ExpenseService with all methods
- Create AuthService for authentication
- Add error handling & logging
```

**Dependencies:** Task 3 (Backend APIs complete)
**Blockers:** Backend running
**Notes:** Test against real backend

---

#### Task 5.2: Redux State Management
- **Assignee:** Dev 2
- **Start:** Jan 12 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Create:**
  - `src/clients/mobile-app/src/redux/store.ts`
  - `src/clients/mobile-app/src/redux/slices/authSlice.ts`
  - `src/clients/mobile-app/src/redux/slices/expenseSlice.ts`
  - Redux middleware

**Checklist:**
- [ ] Setup Redux store
- [ ] Create auth slice (login, logout, state)
- [ ] Create expense slice (list, add, update, delete)
- [ ] Create selectors
- [ ] Setup async thunks
- [ ] Add Redux middleware
- [ ] Connect to React components
- [ ] Test Redux flow

**Acceptance Criteria:**
```
✅ Redux store working
✅ Slices created
✅ Async thunks working
✅ Selectors working
✅ State updates properly
```

**Git Commit Message:**
```
feat(mobile): Setup Redux state management

- Create Redux store with slices
- Implement auth slice with thunks
- Implement expense slice with CRUD
- Add selectors & middleware
- Full Redux integration
```

**Dependencies:** Task 5.1
**Blockers:** None
**Notes:** Use Redux Toolkit

---

#### Task 5.3: Integrate Screens with APIs
- **Assignee:** Dev 2
- **Start:** Jan 13 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL
- **Files to Update:**
  - `src/clients/mobile-app/src/screens/Auth/*.tsx`
  - `src/clients/mobile-app/src/screens/Expenses/*.tsx` (needs creation)

**Checklist:**
- [ ] Connect LoginScreen to Redux
- [ ] Connect RegisterScreen to Redux
- [ ] Create ExpenseListScreen
- [ ] Create AddExpenseScreen with form
- [ ] Create EditExpenseScreen
- [ ] Connect to expense APIs
- [ ] Handle loading states
- [ ] Handle error states
- [ ] Add success messages
- [ ] Test all flows

**Acceptance Criteria:**
```
✅ Auth screens call APIs
✅ Expenses fetch from API
✅ Add/edit/delete working
✅ Loading indicators show
✅ Errors handled gracefully
✅ User feedback clear
```

**Git Commit Message:**
```
feat(mobile): Integrate screens with backend APIs

- Connect auth screens to authentication APIs
- Create & connect expense screens
- Implement loading & error states
- Add user feedback messages
- Full mobile-backend integration
```

**Dependencies:** Tasks 5.1, 5.2, Task 3 (Backend complete)
**Blockers:** None
**Notes:** Ensure error handling is robust

---

### **💼 DEV 4 - Web Admin Dashboard**

**Total Hours:** 40h | **Start:** Jan 11 | **End:** Jan 24

#### Task 6.1: Admin Dashboard - Statistics & Analytics
- **Assignee:** Dev 4
- **Start:** Jan 11 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files to Create:**
  - `src/clients/web-admin/src/pages/Dashboard/AdminDashboard.jsx`
  - `src/clients/web-admin/src/components/StatisticCard.jsx`
  - `src/clients/web-admin/src/components/ChartComponent.jsx`

**Checklist:**
- [ ] Create admin dashboard page
- [ ] Display user count statistics
- [ ] Display transaction statistics
- [ ] Add bar chart for transactions
- [ ] Add pie chart for categories
- [ ] Add revenue trend chart
- [ ] Add filters (date range)
- [ ] Mock data or connect to analytics API
- [ ] Responsive design

**Acceptance Criteria:**
```
✅ Dashboard displays all stats
✅ Charts render correctly
✅ Filters working
✅ Responsive layout
✅ Data updates properly
```

**Git Commit Message:**
```
feat(admin): Create admin dashboard

- Add statistics cards
- Add charts (bar, pie, trend)
- Implement date range filters
- Connect to analytics API
- Fully responsive design
```

**Dependencies:** Task 4.1 (API testing done)
**Blockers:** Analytics API endpoints needed
**Notes:** Use ECharts or Recharts for charts

---

#### Task 6.2: Admin - Blog Management
- **Assignee:** Dev 4
- **Start:** Jan 13 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files to Create:**
  - `src/clients/web-admin/src/pages/Blogs/BlogList.jsx`
  - `src/clients/web-admin/src/pages/Blogs/BlogCreate.jsx`
  - `src/clients/web-admin/src/pages/Blogs/BlogEdit.jsx`

**Checklist:**
- [ ] Create blog list page with DataTable
- [ ] Create blog create page with form
- [ ] Create blog edit page
- [ ] Add rich text editor
- [ ] Add publish/draft status
- [ ] Add author assignment
- [ ] Add date picker
- [ ] Connect to blog API
- [ ] Test CRUD operations

**Acceptance Criteria:**
```
✅ Blog list displays
✅ Create/edit forms work
✅ Rich text editor functional
✅ Status management working
✅ API integration complete
```

**Git Commit Message:**
```
feat(admin): Add blog management

- Create blog list page
- Create blog create/edit forms
- Add rich text editor
- Implement status management
- Full blog CRUD working
```

**Dependencies:** Task 4.1 (Blog APIs exist)
**Blockers:** None
**Notes:** Use react-quill for rich text editor

---

#### Task 6.3: Web Admin - Complete User Management
- **Assignee:** Dev 4
- **Start:** Jan 14 | **Duration:** 1.5 days (12h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH
- **Files to Update:**
  - `src/clients/web-admin/src/pages/Users/UserList.jsx`
  - `src/clients/web-admin/src/pages/Users/UserDetail.jsx`

**Checklist:**
- [ ] Complete user list page with sorting
- [ ] Complete user detail/edit page
- [ ] Add user role assignment
- [ ] Add user status toggle (active/inactive)
- [ ] Add delete user functionality
- [ ] Add confirmation dialogs
- [ ] Connect to user API
- [ ] Add pagination
- [ ] Add search

**Acceptance Criteria:**
```
✅ All user operations working
✅ Role assignment working
✅ Status toggle working
✅ Pagination working
✅ Search working
✅ Confirmations shown
```

**Git Commit Message:**
```
feat(admin): Complete user management

- Implement full user list with sorting
- Complete user detail/edit forms
- Add role & status management
- Implement delete with confirmation
- Full user API integration
```

**Dependencies:** Task 4.2 (Structure created)
**Blockers:** None
**Notes:** Add confirmation before delete

---

### **🔧 DEV 1 & DEV 3 - Optimization & Review**

**Total Hours:** Combined 30h | **Start:** Jan 11 | **End:** Jan 24

#### Task 7.1: Code Review & Optimization
- **Assignee:** Dev 1 & Dev 3 (combined)
- **Start:** Jan 11 | **Duration:** Ongoing (1-2h/day)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH

**Checklist:**
- [ ] Review Task 5 code (Mobile API Integration)
- [ ] Review Task 6 code (Web Admin)
- [ ] Provide feedback on performance
- [ ] Suggest optimizations
- [ ] Check for security issues
- [ ] Verify testing coverage
- [ ] Help fix any issues
- [ ] Approve PRs

**Acceptance Criteria:**
```
✅ All code reviewed
✅ Feedback provided
✅ Issues fixed
✅ Code approved
```

---

#### Task 7.2: Backend Optimization & Testing
- **Assignee:** Dev 1 & Dev 3
- **Start:** Jan 20 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH

**Checklist:**
- [ ] Performance test APIs (load testing)
- [ ] Optimize slow queries
- [ ] Add database indexes
- [ ] Review error handling
- [ ] Add missing validations
- [ ] Update documentation
- [ ] Prepare for next phase

**Acceptance Criteria:**
```
✅ API response time <200ms
✅ No N+1 queries
✅ Error handling complete
✅ Documentation updated
```

---

## 🎯 PHASE 3: TUẦN 4-6 (AI/ML + Testing + Deployment)

### **🤖 DEV 3 - AI/ML Integration**

#### Task 8.1: OCR Service Implementation
- **Assignee:** Dev 3
- **Start:** Jan 25 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL

**Files to Create:**
- `src/backend/Fepa.CoreService/Fepa.Application/Services/OcrService.cs`
- `src/backend/Fepa.CoreService/Fepa.API/Controllers/FileController.cs`

**Checklist:**
- [ ] Choose OCR provider (Google Vision / Azure)
- [ ] Create OcrService wrapper
- [ ] Create file upload endpoint
- [ ] Extract text from invoice images
- [ ] Extract amount from OCR result
- [ ] Extract date from OCR result
- [ ] Store images in cloud storage
- [ ] Link images to expenses
- [ ] Test accuracy

**Acceptance Criteria:**
```
✅ OCR extracts text accurately
✅ Amount extraction working
✅ Date extraction working
✅ File upload working
✅ Cloud storage linked
```

---

#### Task 8.2: ML Expense Classification
- **Assignee:** Dev 3
- **Start:** Jan 27 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL

**Files to Create:**
- `src/backend/ml-models/expense_classifier.py`
- `src/backend/Fepa.CoreService/Fepa.Application/Services/ClassificationService.cs`

**Checklist:**
- [ ] Collect training data
- [ ] Build Naive Bayes classifier
- [ ] Train model on expense descriptions
- [ ] Evaluate model accuracy
- [ ] Save model to file
- [ ] Create ClassificationService
- [ ] Integrate with expense creation API
- [ ] Auto-assign categories
- [ ] Test with sample expenses

**Acceptance Criteria:**
```
✅ Model trained and saved
✅ Classification accuracy >80%
✅ Auto-classification working
✅ Predictions logged
```

---

#### Task 8.3: Spending Prediction Model
- **Assignee:** Dev 3
- **Start:** Jan 29 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH

**Files to Create:**
- `src/backend/ml-models/spending_predictor.py`
- `src/backend/Fepa.CoreService/Fepa.API/Controllers/PredictionController.cs`

**Checklist:**
- [ ] Collect historical expense data
- [ ] Build ARIMA/Prophet model
- [ ] Train on user patterns
- [ ] Generate predictions
- [ ] Add confidence intervals
- [ ] Create prediction API
- [ ] Add recommendations
- [ ] Test predictions

**Acceptance Criteria:**
```
✅ Model predictions accurate
✅ Prediction API working
✅ Recommendations generated
✅ Confidence intervals shown
```

---

### **🔐 DEV 1 - Security Hardening**

#### Task 9.1: 2FA & Email Verification Complete
- **Assignee:** Dev 1
- **Start:** Jan 25 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL

**Checklist:**
- [ ] Uncomment EmailVerificationService
- [ ] Uncomment PasswordResetService
- [ ] Implement email verification workflow
- [ ] Implement password reset flow
- [ ] Add backup codes for 2FA
- [ ] Test email delivery
- [ ] Test 2FA setup process
- [ ] Security audit

**Acceptance Criteria:**
```
✅ Email verification working
✅ Password reset working
✅ 2FA setup complete
✅ Backup codes generated
✅ All flows tested
```

---

#### Task 9.2: Security Audit & Hardening
- **Assignee:** Dev 1
- **Start:** Jan 27 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL

**Checklist:**
- [ ] Input validation audit
- [ ] SQL injection prevention
- [ ] XSS prevention
- [ ] Rate limiting implementation
- [ ] Encrypt sensitive data
- [ ] Secure OAuth token storage
- [ ] Password strength requirements
- [ ] Session management
- [ ] Security testing

**Acceptance Criteria:**
```
✅ No SQL injection vulnerabilities
✅ No XSS vulnerabilities
✅ Rate limiting working
✅ Sensitive data encrypted
✅ Security audit passed
```

---

### **📱 DEV 2 - Mobile Refinement**

#### Task 10.1: Offline Mode & Local Storage
- **Assignee:** Dev 2
- **Start:** Jan 25 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL

**Checklist:**
- [ ] Setup SQLite database
- [ ] Create local schema
- [ ] Implement sync logic
- [ ] Queue offline operations
- [ ] Detect network changes
- [ ] Sync on reconnect
- [ ] Conflict resolution
- [ ] Test offline scenarios

**Acceptance Criteria:**
```
✅ Offline mode working
✅ Data persists locally
✅ Sync working
✅ Conflicts resolved
✅ User notified of status
```

---

#### Task 10.2: Mobile Testing & Polish
- **Assignee:** Dev 2
- **Start:** Jan 27 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH

**Checklist:**
- [ ] Unit tests for services
- [ ] Integration tests
- [ ] UI/E2E tests
- [ ] Performance testing
- [ ] Bug fixes
- [ ] Polish animations
- [ ] Optimize images
- [ ] App store preparation

**Acceptance Criteria:**
```
✅ All tests pass
✅ >80% code coverage
✅ App runs smoothly
✅ No crashes
✅ Store ready
```

---

### **🐳 DEV 4 - Deployment & Documentation**

#### Task 11.1: Docker & Cloud Setup
- **Assignee:** Dev 4
- **Start:** Jan 25 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL

**Checklist:**
- [ ] Create Dockerfile for API
- [ ] Create docker-compose.yml
- [ ] Setup PostgreSQL on cloud
- [ ] Test local Docker stack
- [ ] Configure environment variables
- [ ] Setup CI/CD pipeline
- [ ] Deploy to staging
- [ ] Test in cloud

**Acceptance Criteria:**
```
✅ Docker working locally
✅ Cloud database ready
✅ API deployable
✅ CI/CD configured
✅ Staging deployment working
```

---

#### Task 11.2: Complete Documentation
- **Assignee:** Dev 4
- **Start:** Jan 27 | **Duration:** 3 days (24h)
- **Status:** 🔵 Not Started
- **Priority:** 🟡 HIGH

**Files to Create:**
- `docs/SRS.md` - Software Requirements Specification
- `docs/SDD.md` - Software Design Document
- `docs/TEST_PLAN.md` - Test Plan
- `docs/USER_MANUAL.md` - User Manual
- `docs/DEPLOYMENT_GUIDE.md` - Deployment Guide
- `docs/API_REFERENCE.md` - API Reference
- `docs/DEVELOPER_GUIDE.md` - Developer Guide

**Checklist:**
- [ ] Write complete SRS
- [ ] Write complete SDD
- [ ] Write test plan with test cases
- [ ] Write user manual with screenshots
- [ ] Write deployment guide
- [ ] Export Swagger API docs
- [ ] Write developer setup guide
- [ ] Create training materials

**Acceptance Criteria:**
```
✅ All documentation complete
✅ Screenshots included
✅ Setup instructions clear
✅ API fully documented
✅ Test cases documented
```

---

#### Task 11.3: Production Deployment
- **Assignee:** Dev 4
- **Start:** Feb 3 | **Duration:** 2 days (16h)
- **Status:** 🔵 Not Started
- **Priority:** 🔴 CRITICAL (FINAL)

**Checklist:**
- [ ] Final security audit
- [ ] Final performance testing
- [ ] Setup monitoring
- [ ] Setup logging
- [ ] Deploy to production
- [ ] Configure domain/SSL
- [ ] Deploy admin dashboard
- [ ] Deploy mobile builds
- [ ] Final smoke testing
- [ ] Go-live communication

**Acceptance Criteria:**
```
✅ All systems running
✅ No errors
✅ Performance acceptable
✅ Monitoring active
✅ Backups configured
✅ Users can access
```

---

## 📊 TASK SUMMARY TABLE

| Phase | Week | Dev | Task Count | Total Hours | Status |
|-------|------|-----|-----------|-------------|--------|
| Phase 1 | 1-2 | Dev 1 | 4 | 30h | Not Started |
| | | Dev 2 | 3 | 32h | Not Started |
| | | Dev 3 | 4 | 40h | Not Started |
| | | Dev 4 | 2 | 20h | Not Started |
| Phase 2 | 2-3 | Dev 2 | 3 | 40h | Not Started |
| | | Dev 4 | 3 | 40h | Not Started |
| | | Dev 1,3 | 2 | 30h | Not Started |
| Phase 3 | 4-6 | Dev 1 | 2 | 32h | Not Started |
| | | Dev 2 | 2 | 32h | Not Started |
| | | Dev 3 | 3 | 48h | Not Started |
| | | Dev 4 | 3 | 56h | Not Started |
| **TOTAL** | **6 Weeks** | **4 Devs** | **31 Tasks** | **420 Hours** | - |

---

## 🚀 QUICK START GUIDE FOR DEVELOPERS

### **For Dev 1 (OAuth & Security Lead):**
```bash
# Day 1 - Start with Google OAuth
cd src/backend/Fepa.CoreService/Fepa.Application/Services
# Edit GoogleOAuthService.cs
# Branch: feature/google-oauth

# Get Google OAuth credentials from:
https://console.cloud.google.com
```

### **For Dev 2 (Mobile Lead):**
```bash
# Day 1 - Setup project structure
cd src/clients/mobile-app/src
# Create folder structure
# Install React Navigation
# Branch: feature/mobile-foundation

# npm install @react-navigation/native @react-navigation/bottom-tabs
```

### **For Dev 3 (Backend APIs):**
```bash
# Day 1 - Create Expense entities
cd src/backend/Fepa.CoreService/Fepa.Domain/Entities
# Create Expense.cs and Category.cs
# Branch: feature/expense-model

# Create migration:
# cd Fepa.CoreService
# dotnet ef migrations add AddExpenseModel
```

### **For Dev 4 (Admin & DevOps):**
```bash
# Day 1 - Test existing APIs
cd src/backend/Fepa.CoreService/Fepa.API
# Open Fepa.API.http in VS Code REST Client
# Test all endpoints
# Branch: chore/api-testing
```

---

## 📋 DAILY STANDUP TEMPLATE

**Time:** 9:00 AM | **Duration:** 15 min

```
Developer: [Name]
Status: [In Progress / Blocked / Completed]

Yesterday:
- What did you complete?

Today:
- What will you complete?

Blockers:
- Any issues?

PRs:
- Any PRs waiting for review?
```

---

## ✅ ACCEPTANCE TEST CHECKLIST

Each task must pass before moving to next:

```
Code Quality:
✅ TypeScript/C# no errors
✅ ESLint/StyleCop no warnings
✅ Code follows project patterns
✅ Code reviewed by 2+ devs

Testing:
✅ Unit tests written
✅ All tests pass
✅ >80% code coverage
✅ Integration tests pass

Documentation:
✅ Comments added for complex logic
✅ README updated if needed
✅ Swagger/API docs updated

Git:
✅ Commit message follows convention
✅ PR description complete
✅ No merge conflicts
✅ Approved & merged
```

---

## 📞 COMMUNICATION CHANNELS

- **Daily Standup:** Slack + Voice (9:00 AM)
- **Code Review:** GitHub PRs
- **Blockers:** Immediate Slack mention
- **Weekly Review:** Friday 5:00 PM
- **Documentation:** Shared Wiki/Confluence

---

**Last Updated:** January 3, 2026  
**Project Manager:** [Your Name]  
**Next Review:** January 7, 2026

