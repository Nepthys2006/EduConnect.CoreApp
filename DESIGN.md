EduConnect — Design System & UI Specification
Teacher Dashboard · MAUI C# · Web / App / Desktop

1. Design Philosophy
Direction: Refined Institutional Minimalism
EduConnect sits at the intersection of authority and approachability — used by educators who need clarity, speed, and trust from their tools. The aesthetic is calm precision: generous whitespace, deliberate type hierarchy, and a restrained palette that communicates professionalism without coldness.
The design avoids:

Drop shadows everywhere (use sparingly, only for floating elements)
Gradient-heavy hero sections bleeding into content
Cluttered sidebars with icons for every action
Generic "dashboard blue" that looks like every SaaS tool

The design commits to:

A sidebar that breathes — label-forward navigation, not icon-only
Cards with intentional micro-borders and subtle elevation
Status communication through color and shape, never color alone
Typography that carries the UI, not decorations


2. Color System
--color-surface-base:     #F7F8FA   /* page background */
--color-surface-card:     #FFFFFF   /* card / panel background */
--color-surface-sidebar:  #111318   /* sidebar — deep charcoal, not pure black */
--color-surface-raised:   #EDEEF1   /* input backgrounds, table rows alt */

--color-border-subtle:    #E4E5E9   /* dividers, card borders */
--color-border-default:   #C9CBD2   /* input borders */
--color-border-strong:    #8F92A1   /* focus rings, active states */

--color-primary:          #2563EB   /* EduConnect blue — action buttons, links */
--color-primary-hover:    #1D4ED8
--color-primary-subtle:   #EFF6FF   /* light tint for selected states */

--color-accent:           #0EA5E9   /* secondary accent — badges, highlights */

--color-success:          #16A34A
--color-success-surface:  #F0FDF4
--color-warning:          #D97706
--color-warning-surface:  #FFFBEB
--color-danger:           #DC2626
--color-danger-surface:   #FEF2F2
--color-neutral:          #6B7280

--color-text-primary:     #111318   /* headings */
--color-text-secondary:   #4B5563   /* body, labels */
--color-text-tertiary:    #9CA3AF   /* placeholders, timestamps */
--color-text-inverse:     #FFFFFF   /* on dark sidebar */
--color-text-link:        #2563EB
Sidebar exception: The sidebar uses --color-surface-sidebar (#111318) with white text. Active nav items use a rgba(255,255,255,0.10) background pill. This creates a confident anchor without fighting the content area.

3. Typography
Font Stack:
RoleFontWeightSizeDisplay / Page TitleDM Sans60022–28pxSection HeaderDM Sans60016–18pxBody / LabelsDM Sans40014pxCaption / TimestampDM Sans40012pxMonospace (LRN, IDs)JetBrains Mono40013pxNumbers / ScoresDM Sans700varies

Why DM Sans: Clean geometric humanist sans. Warmer than Inter, more institutional than Outfit. Reads beautifully at small sizes on both screen and mobile.

Type Scale:
--text-xs:   11px / line-height 1.4
--text-sm:   13px / line-height 1.5
--text-base: 14px / line-height 1.6
--text-md:   16px / line-height 1.5
--text-lg:   18px / line-height 1.4
--text-xl:   22px / line-height 1.3
--text-2xl:  28px / line-height 1.2

4. Spacing System
8px base grid. All spacing values are multiples of 4 or 8.
--space-1:  4px
--space-2:  8px
--space-3:  12px
--space-4:  16px
--space-5:  20px
--space-6:  24px
--space-8:  32px
--space-10: 40px
--space-12: 48px
--space-16: 64px

5. Layout Structure
┌──────────────────────────────────────────────────────────┐
│  TOPBAR  (48px height, sticky)                           │
├──────────┬───────────────────────────────────────────────┤
│          │                                               │
│ SIDEBAR  │         CONTENT AREA                         │
│ (220px)  │         (fluid, scrollable)                  │
│          │                                               │
│          │                                               │
└──────────┴───────────────────────────────────────────────┘
Topbar:

Height: 48px
Background: --color-surface-card with border-bottom: 1px solid --color-border-subtle
Contains: App logo (left), Page title center on mobile, Notification bell + Settings gear + Avatar (right)
The topbar is utility-only — not primary navigation

Sidebar (Teacher):

Width: 220px (collapsible to 56px on smaller screens)
Background: #111318
Nav items: 40px height, 12px horizontal padding, 8px border-radius
Active state: rgba(255,255,255,0.10) background pill, text #FFFFFF
Inactive state: text rgba(255,255,255,0.55)
Section labels (e.g., "CLASSES", "ACCOUNT"): 10px uppercase, rgba(255,255,255,0.30), letter-spacing 0.08em
Bottom: Teacher name + avatar above Sign Out button
Sign Out: subtle danger color on hover

Content Area:

Max-width: 1100px (centered with auto margins on wide screens)
Padding: 32px horizontal, 28px top
Background: --color-surface-base


6. Component Library
6.1 Buttons
Primary:
  background: --color-primary
  color: white
  padding: 9px 18px
  border-radius: 7px
  font-size: 14px / font-weight: 500
  hover: --color-primary-hover + scale(1.01)
  transition: 150ms ease

Secondary / Ghost:
  background: transparent
  border: 1px solid --color-border-default
  color: --color-text-primary
  Same padding and radius as primary
  hover: background --color-surface-raised

Danger:
  background: --color-danger / color: white

Icon Button:
  32×32px, border-radius: 7px
  hover: background --color-surface-raised
No rounded-full pill buttons except for status badges.

6.2 Cards
background: --color-surface-card
border: 1px solid --color-border-subtle
border-radius: 10px
padding: 20px 24px
No box-shadow by default.

Elevated Card (modals, dropdowns):
  box-shadow: 0 4px 16px rgba(0,0,0,0.08), 0 1px 3px rgba(0,0,0,0.05)

6.3 Input Fields
height: 38px
border: 1px solid --color-border-default
border-radius: 7px
background: --color-surface-raised
font-size: 14px
padding: 0 12px
color: --color-text-primary
placeholder: --color-text-tertiary

focus:
  border-color: --color-primary
  outline: 3px solid rgba(37,99,235,0.15)
  background: white

6.4 Status Badges
Pill-shaped, 5px radius, font-size 11px, font-weight 600, UPPERCASE, letter-spacing 0.04em. Padding: 3px 9px.
StatusBackgroundText ColorPresent--color-success-surface--color-successAbsent--color-danger-surface--color-dangerExcused--color-surface-raised--color-text-secondarySubmitted--color-success-surface--color-successLate--color-warning-surface--color-warningPending--color-warning-surface--color-warningOngoing#EFF6FF--color-primaryUrgent--color-danger-surface--color-danger

6.5 Data Tables
Header row:
  font-size: 11px / font-weight: 600
  text-transform: uppercase / letter-spacing: 0.06em
  color: --color-text-tertiary
  border-bottom: 1px solid --color-border-subtle
  padding: 10px 16px

Data row:
  padding: 14px 16px
  border-bottom: 1px solid --color-border-subtle
  font-size: 14px / color: --color-text-primary
  hover: background --color-surface-base

Last row: no border-bottom

6.6 Tabs (within Class Detail)
Underline-style — no pill or card tabs.
Tab item:
  padding: 10px 0
  margin-right: 24px
  font-size: 14px / color: --color-text-tertiary
  border-bottom: 2px solid transparent

Active tab:
  color: --color-primary
  border-bottom: 2px solid --color-primary
  font-weight: 500

6.7 Avatar
Circular. 32px default, 40px in member/profile lists.
If no photo: initials in --color-primary-subtle background, --color-primary text.
Online presence dot: 8px circle, absolute bottom-right, #16A34A with white 2px ring.

6.8 Class Gradient Presets
Each class gets a gradient from this rotation (6 presets):
1. #6366F1 → #818CF8   (indigo)
2. #2563EB → #06B6D4   (blue-teal)
3. #0EA5E9 → #34D399   (sky-emerald)
4. #10B981 → #A3E635   (green)
5. #F59E0B → #F97316   (amber-orange)
6. #EF4444 → #EC4899   (red-pink)

7. Teacher-Side Screen Specifications
7.1 Sign In

Full-screen background: school building photo, rgba(17,19,24,0.55) overlay
Centered white card: 420px wide, 24px border-radius, no shadow
Gradient logo icon at top of card
Gmail Address field (note: @gmail.com → Student, @deped.gov.ph → Teacher — show as small helper note on email field blur)
Password field + "Forgot password?" right-aligned link
Info note: --color-surface-raised bg + icon prefix, 13px
Sign In: full-width primary button
"Create an account" link below as secondary action


7.2 Sign Up
Same background as Sign In.
Section 1 — Account Details:
Email, Password, Confirm Password
Section 2 — Your Identification:
Last Name, First Name, Middle Name
LRN (auto-label changes to "Employee ID" if @deped.gov.ph detected)
Section 3 — Note:
CEIX/cross-reference info box
Role is auto-detected from email domain. No role dropdown shown to user.

7.3 Teacher Home Dashboard
Welcome Banner:
Contained full-width card (not a page-bleeding hero).

Background: --color-primary + diagonal fine lines texture (4% white opacity)
White heading: "Welcome back, [Name]" (20px 600) + subtext (14px, 85% white)
Two ghost-white buttons: "View Schedule" · "Check Gradebook"
Right side: abstract open-book SVG illustration, muted, ~120px

Two-column layout below banner:
Left (60%) — Create Class card:

Fields: Subject, Grade Level, Section, School Year
"Create" primary button
Clean inline form, no extra decoration

Right (40%) — To-Do / Grading card:

Assignment item rows: name + submission count + due badge
Due badges: "Today" = danger, "Tomorrow" = warning, future = neutral
Max 4 visible, scrollable if more

Upcoming Classes Today — full-width section below:

Each class row: colored 4px left border (from class gradient set), Grade badge, Class name (16px 600), Time + Section (14px tertiary)


7.4 Classes List

School Year filter dropdown top-right
Class cards in 2-column grid (or stacked on narrow)
Each card: gradient background, Section badge (white pill), Class name (20px white bold), Instructor, "Add Students" ghost white button
Blank/unconfigured class cards: gradient only, no text


7.5 Class Detail — Tab Structure
Tabs: Announcements · Content · Assignments · Members · Grades · Messages · Attendance
Shared Class Header:

Same gradient as list card, height ~160px
Section badge + "Add More Students" button
Class name (22px white bold), Instructor (14px white 80%)


7.5.1 Announcements
Posts render as stacked cards.

Post card: Avatar + Name + timestamp (row top), body text, optional file attachments (file chips: icon + name + size, bordered, small, horizontal row)
Three-dot menu: edit / delete
Post Composer (bottom): Textarea + toolbar (Attachment | Schedule) + "Post Update" CTA


7.5.2 Content
3-column grid of module folder cards.

First card always: "Add New Folder" — dashed border, centered plus icon, helper text
Folder card: folder icon (blue), folder name (16px 600), description (13px, 2-line max), item count, expand chevron, plus button
Clicking a folder: expands inline (accordion) showing file list with download/delete actions


7.5.3 Assignments

Header: total count + "Add Assignment" primary CTA (right)
Assignment rows:

Type icon (code = blue, quiz = orange, essay = purple, project = teal)
Name (15px 600) + description (13px tertiary, 1-line truncated)
Due date + Points
Status badge (Pending / Ongoing) if applicable
"View Details" secondary button + three-dot menu


"View Details" opens a right-side drawer (not a new page):

Full assignment description at top
Submission Bin table: Student name, LRN (mono), Submitted at, File link, Grade input (/ pts suffix)
"Save Grades" button at bottom of drawer




7.5.4 Members

Header: total member count + group icon
Member list rows: Avatar, Full Name (with verified checkmark for teacher), Email, Role badge
Teacher row: "Professor" badge in blue
Student rows: "Student" badge in neutral
Three-dot per student: remove from class
"Add Students" at top opens a modal:

Student Join Requests Modal:
Title: "Student Join Requests"
Each row:
  - Avatar placeholder + Name + LRN (mono font)
  - [Accept] green outline button / [Reject] red outline button
  - On accept: inline success state, then row fades out

7.5.5 Grades (Teacher Gradebook)
Full-width table:

Columns: Item Name, Due Date, Status badge, Score (inline editable), Edit icon
Clicking score cell activates number input inline
Summary pinned to bottom: Total Assignments count + Completed count

"End of Term Summary" button (top-right):

Opens a modal with per-student final grade table
Columns: Student name, Total Points Earned, Total Points Possible, Percentage, Letter Grade
Export to CSV or PDF option


7.5.6 Messages
Two-panel layout (left list + right view):
Conversation List (340px):

"New Message" full-width dark button at top
Search bar below
Conversation rows: Avatar + Name + truncated preview + timestamp + unread blue dot

Message View (fluid):

Chat-style: teacher bubbles right-aligned (blue), student bubbles left (gray surface)
Date separator labels (centered, tertiary text)
Bottom: Rich text composer — formatting toolbar (bold, italic, underline, link, image, attach) + Send button


7.5.7 Attendance
Calendar (top):

Full month grid, minimal styling
Days with recorded sessions: small blue dot under date
Today: filled primary circle
Navigation: previous/next month chevrons

Date Selector: Input defaulting to today's date
Student Roster Table:

Columns: Student (avatar + name), LRN# (mono), Status badge, Toggle row (✓ Present / ✗ Absent buttons)
"Mark All Present" shortcut above table
Status updates live on toggle — no save button needed (auto-save with toast confirmation)


7.6 Calendar Page

Full calendar grid (month view), color-coded event chips per class
Event chip colors map to class gradient presets
Right side panel:

Upcoming Grading: Deadline list with urgency badges + item counts
Recent Submissions: Last 4 submissions with student name, class, timestamp, "New" badge


"+ Add Assignment" button in topbar of this page (opens assignment creation modal)


7.7 Activity Center
Tabs: All · Messages · Submissions · Alerts

Flat list (no cards), subtle row hover
Each item: Contextual icon + Activity title + Category label + Timestamp right-aligned
Filter tabs narrow the list in place
Empty state: centered muted icon + "No recent activity" text


7.8 Profile Page

80px avatar with pencil overlay on hover
Name (22px 600) + Role badge + Email (subdued) beneath avatar

Two-column layout:
Left — Basic Information card:

Full Name, Email Address, Employee/LRN ID, Password (masked + "Change password" link)
"Edit Details" button top-right of card

Right — Additional Information card:

Gender, Additional Name (+ add link), Birthday, Education Level, Website (+ add link)

Below — Contact Information card:

Mailing Address, Phone Number

Edit mode: fields become inputs inline — no separate modal.

8. Motion & Transitions
Keep animations fast and purposeful. Productivity app, not a marketing site.
Page transitions:       200ms fade-in (opacity 0 → 1)
Tab switches:           150ms fade + translateY(4px → 0)
Card hover:             120ms border-color change
Button press:           80ms scale(0.98)
Dropdown open:          150ms translateY(-4px → 0) + opacity
Modal open:             180ms scale(0.97 → 1) + opacity
Sidebar collapse:       200ms width
Status badge change:    100ms background-color
Row hover background:   100ms
Toast notification:     200ms slideIn from right, auto-dismiss 3s
No bounce, no spring physics, no easing curves over 200ms. Snap and confident.

9. Iconography
Use Phosphor Icons — Regular weight throughout. Do not mix weights on the same screen.
UI LocationIconHome navHouseClasses navBookOpenCalendar navCalendarBlankActivity navChartLineProfile navUserNotificationsBellSettingsGearSixSign OutSignOutMembers tabUsersAssignments tabClipboardTextContent tabFoldersGrades tabExamMessages tabChatCircleAttendance tabCheckSquareCreate / AddPlusContext menuDotsThreeVerticalVerified badgeSealCheckFile attachmentPaperclipCode assignmentCodeQuiz assignmentListChecksEssay assignmentPencilLine

10. Responsive Behavior (MAUI Web / Desktop / App)
Desktop (≥ 1024px):
Full sidebar (220px) always visible. Two-column layouts active. Class grid: 2 columns.
Tablet (768–1023px):
Sidebar collapses to icon-only (56px). Two-column layouts stack vertically. Class grid: 1 column. Class tabs: horizontal scroll.
Mobile (< 768px):
Sidebar replaced by bottom tab bar (5 primary tabs: Home, Classes, Calendar, Activity, Profile). Content full width. All cards full width. Right-side panels (Messages) become full screen views. Drawers open from bottom.

11. Accessibility

Minimum contrast: 4.5:1 for body text, 3:1 for large text/icons
Focus rings: outline: 3px solid rgba(37,99,235,0.20) + outline-offset: 2px on all interactive elements
Status never communicated by color alone — always paired with label text or icon
Touch targets minimum 44×44px on mobile
Modals: focus trapped on open, restored on close
All form fields have visible labels (no placeholder-only labels)
All images have descriptive alt text