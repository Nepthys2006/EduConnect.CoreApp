# CRITICAL RULES - MUST FOLLOW

## RESPONSES

- Keep responses concise and to the point - unless the user asks otherwise

## PLANNING MODE

- Always ask clarifying questions
- Never assume design, tech stack or features
- Use deep-dive sub-agents to assist with research
- Use deep-dive sub-agents to review the different aspects of your plan before presenting to the user

## CODE STRUCTURE

- Ensure to follow MVVM architecture
- Ensure to create a Clean code architecture (separate business logic from UI)
- Ensure to follow @STRUCTURE.md when creating new pages, components, etc.

## CHANGE / EDIT MODE

- Never implement features yourself when possible - use sub-agents!
- Identify changes from the plan that can be implemented in parallel, and use sub-agents to implement the features efficiently
- When using sub-agents to implement features, act as a coordinator only
- Use the best model for the task - premium models for complex tasks (like coding) and mid-tier models for simpler tasks, like documentation
- After completing features (large or small), always run commands like lint, type check and next build to check code quality

## DATABASE SCHEMA CHANGES

- Whenever you make changes to the database schema, ALWAYS run the drizzle generate and migrate commands
- NEVER run drizzle push!

## TESTING

- Use any testing tools, libraries available to the project for testing your changes
- Never assume your changes simply work, always test!
- If the project does not have any testing tools, scripts, MCP tools, skills, etc. available for testing, ask the user whether testing should be skipped.

## UI DESIGN

- Always follow the UI design system when creating or reviewing components or pages.
- Design System: @DESIGN.md

---

## Project Architecture (Verified)

**Stack**: .NET MAUI Blazor Hybrid + Blazor Web. Shared Razor components in `EduConnect.SharedUI` render on both MAUI (mobile/desktop) and Web.

**Solution**: `EduConnect.slnx` — multi-project, NOT a monorepo with separate package managers.

| Project | Role |
|---------|------|
| `EduConnect.Domain` | POCO entities, no dependencies |
| `EduConnect.Infrastructure` | Infrastructure concerns |
| `EduConnect.Api` | ASP.NET Core API (minimal) |
| `EduConnect.SharedUI` | Razor components, CSS themes, mock services — referenced by Maui + Web |
| `EduConnect.Maui` | MAUI Blazor Hybrid app (`net10.0-android`, `ios`, `maccatalyst`, `windows10.0.19041.0`) |
| `EduConnect.Web` | ASP.NET Core Blazor Web app |
| `EduConnect.RealTime` | Present in slnx but may be unreferenced currently |

## Key Conventions

- **Fonts loaded in MauiProgram.cs**: `OpenSans-Regular.ttf` and `DM Sans` (via Google Fonts CDN in `index.html`). Do not add fonts in SharedUI; MAUI owns font registration.
- **CSS theme files**: Lives in `EduConnect.SharedUI/wwwroot/`:
  - `educonnect-theme.css` — Design System tokens (colors, spacing, typography, buttons, inputs, cards, tables, tabs, badges, modals, drawers, toasts, animations).
  - `educonnect-teacher.css` — Layout styles for all Teacher pages and Class Detail tabs.
- **Dependencies**: `SharedUI` references `Domain` only. `Maui` and `Web` reference `SharedUI` and `Domain`.
- **Routing**: `Routes.razor` in Maui/Web MUST include `AdditionalAssemblies="new[] { typeof(EduConnect.SharedUI.Components.DashboardContent).Assembly }"` so pages inside `SharedUI` are routable.
- **`_Imports.razor`**: Both `Maui/Components/_Imports.razor` and `Web/Components/_Imports.razor` must include `@using EduConnect.SharedUI.Components.Pages` and `@using EduConnect.SharedUI.Components.Views` or views will fail to resolve.

## Build Commands

```bash
# Build entire solution
dotnet build

# Build specific project
dotnet build EduConnect.SharedUI/EduConnect.SharedUI.csproj
dotnet build EduConnect.Maui/EduConnect.Maui.csproj
```

## Data Model Quirk

- `User.LearnerReferenceNumber` is typed as `long?` (not `int?`). LRN values exceed `int.MaxValue`. Always use the `L` suffix when assigning mock constants.

## SharedUI Component Namespace Rule

- All routable pages must be in `EduConnect.SharedUI.Components.Pages`.
- All tab views (non-routable child components) must be in `EduConnect.SharedUI.Components.Views`.
- Always use `@using EduConnect.SharedUI.Components.Views` when referencing tab views inside `ClassDetailPage.razor`.

## Mock Services (Current Setup)

- `IAuthService` / `MockAuthService` — detects role from email domain (`@deped.gov.ph` → Teacher, otherwise Student).
- `IDataService` / `MockDataService` — in-memory mock data for classes, assignments, submissions, attendance, messages, calendar, activities.
- Registered as singletons in `MauiProgram.cs`.

## Mobile / Responsive

- Sidebar collapses to 56px icon-only at tablet (768–1023px).
- Sidebar is completely hidden on mobile (<768px); a bottom tab bar is rendered by `MainLayout.razor`.
- All page CSS handles mobile stacking via media queries defined in `educonnect-teacher.css`.

## Anti-AI-Slop Design Mandate (from DESIGN.md)

- Use CSS custom properties (`--color-*`, `--space-*`, `--text-*`) defined in `educonnect-theme.css`. Do not invent new colors.
- Cards use `1px solid var(--color-border-subtle)` borders; **no default box-shadow** on cards.
- Buttons use `border-radius: 7px`. Only status badges use pill shape.
- No gradient hero sections bleeding into content. The welcome banner is a contained card.
- Typography (DM Sans) carries hierarchy, not decorations.

## Existing Teacher Pages (do not duplicate)

- `TeacherDashboard.razor` (`/`)
- `ClassesPage.razor` (`/classes`)
- `ClassDetailPage.razor` (`/class/{ClassId}`) with tabs: Announcements, Content, Assignments, Members, Grades, Messages, Attendance
- `CalendarPage.razor` (`/calendar`)
- `ActivityPage.razor` (`/activity`)
- `ProfilePage.razor` (`/profile`)
