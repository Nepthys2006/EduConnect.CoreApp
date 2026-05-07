# EduConnect — Design Language System
### A living document for visual and interaction design decisions

---

## Design Philosophy

EduConnect is built on a single conviction: **clarity is care**.

Teachers manage dozens of competing priorities every day. Students navigate anxiety, distraction, and hope simultaneously. Every pixel in this interface is an act of respect for that reality. We don't decorate. We don't impress. We make the next right action obvious.

The aesthetic draws from **institutional modernism** — the quiet authority of a well-designed university campus, the legibility of a good textbook, the calm of a reading room. Think less "Silicon Valley SaaS," more "a school that actually works."

**Three words that govern every decision:**

> **Calm. Clear. Considered.**

If a design element cannot be justified by at least one of these, it does not belong.

---

## What This Design Is Not

Understanding what to avoid is as important as knowing what to pursue. EduConnect must never feel like:

- A startup dashboard from a Dribbble showcase — no glassmorphism, no neon accents, no floating blobs
- A government portal — no grey-on-grey, no Times New Roman, no 1998-era form layouts
- A generic "AI-designed" app — no purple-to-blue hero gradients, no Inter/Roboto everywhere, no predictable card grids with identical shadows and identical hover lifts
- An enterprise tool — no data-density for its own sake, no collapsed sidebars hiding seven levels of navigation

---

## Typography

Typography is the single most powerful tool in a minimalist design system. Every type decision must feel deliberate.

### Typeface Choices

**Display & Headings — `Instrument Serif` (Google Fonts)**

Instrument Serif brings warmth and authority to large headings. Its optical sizing feels editorial, not corporate. Use it for page titles, empty-state headings, and the welcome banner. It is the emotional anchor of the interface — seen rarely, felt always.

```
font-family: 'Instrument Serif', Georgia, serif;
```

Why this font: It has the texture of a well-used textbook, not a pitch deck. It signals permanence and trust without being stiff.

**Body & UI — `Figtree` (Google Fonts)**

Figtree is a geometric sans-serif with humanist proportions. It is warm without being playful, precise without being cold. Unlike Inter or Roboto, it has a subtle personality — slightly rounded terminals, an open aperture — that makes long reading comfortable.

```
font-family: 'Figtree', system-ui, sans-serif;
```

**Monospace — `JetBrains Mono` (Google Fonts)**

Used only for LRN numbers, scores, timestamps, and any data that benefits from tabular alignment. Its large x-height and distinct letterforms prevent misreading of 0 vs O, 1 vs l.

```
font-family: 'JetBrains Mono', 'Courier New', monospace;
```

### Type Scale

The scale uses a 1.25 Major Third ratio. All values are in `rem` assuming 16px base.

```
--text-2xs:   0.625rem;    /* 10px — legal, metadata only */
--text-xs:    0.75rem;     /* 12px — labels, captions, file sizes */
--text-sm:    0.875rem;    /* 14px — secondary body, helper text */
--text-base:  1rem;        /* 16px — primary body copy */
--text-md:    1.125rem;    /* 18px — emphasized body, card titles */
--text-lg:    1.25rem;     /* 20px — section headers */
--text-xl:    1.5rem;      /* 24px — page subheadings */
--text-2xl:   1.875rem;    /* 30px — page titles (Figtree) */
--text-3xl:   2.25rem;     /* 36px — display headings (Instrument Serif) */
--text-4xl:   3rem;        /* 48px — hero/welcome only (Instrument Serif) */
```

### Font Weights

Only four weights are permitted. Using more creates visual noise.

```
--weight-regular:   400;   /* Body copy, helper text */
--weight-medium:    500;   /* Nav labels, table headers, secondary emphasis */
--weight-semibold:  600;   /* Card titles, button labels, primary emphasis */
--weight-bold:      700;   /* Page titles, counts/numbers that anchor a view */
```

### Line Heights

```
--leading-tight:   1.2;   /* Display text, Instrument Serif headings */
--leading-snug:    1.35;  /* Large UI text, card titles */
--leading-normal:  1.5;   /* Body copy, form labels */
--leading-relaxed: 1.65;  /* Paragraphs in announcements, long descriptions */
```

### Letter Spacing

```
--tracking-tight:   -0.02em;  /* Instrument Serif 30px+ */
--tracking-normal:   0em;     /* Default body */
--tracking-wide:     0.04em;  /* UPPERCASE labels, section metadata */
--tracking-widest:   0.08em;  /* Small caps labels like "TOTAL MEMBERS" */
```

### Typography Rules

1. Never use `font-weight: bold` inline — use the weight variables.
2. Uppercase text (`text-transform: uppercase`) is only used for categorical labels (e.g., "TOTAL TASKS," "YOUR IDENTIFICATION"). Never for headings.
3. Instrument Serif is never used below `1.5rem`. Its elegance collapses at small sizes.
4. Long paragraphs (announcements, descriptions) are capped at `68ch` line length to preserve readability.
5. Color contrast for body text must always exceed 4.5:1 (WCAG AA).

---

## Color

The palette is built on restraint. One primary, one accent, a neutral ramp, and semantic colors for data states. Nothing else.

### Foundational Palette

The base is **slate-tinted white** — not pure `#FFFFFF`, which reads as harsh on screens. Every neutral has a slight cool lean that communicates precision without coldness.

```css
/* === Backgrounds === */
--color-canvas:         #F7F8FA;   /* Page background — off-white with blue undertone */
--color-surface:        #FFFFFF;   /* Cards, panels, modals */
--color-surface-raised: #FFFFFF;   /* Elevated cards (with heavier shadow, not different color) */
--color-surface-inset:  #F1F3F6;   /* Input fields, code blocks, inset areas */

/* === Borders & Dividers === */
--color-border-subtle:  #EAECF0;   /* Lowest-emphasis dividers */
--color-border:         #D5D9E2;   /* Standard card/input borders */
--color-border-strong:  #B0B8C8;   /* Focused inputs, active tabs */

/* === Neutral Text === */
--color-text-primary:   #111827;   /* Headings, primary labels */
--color-text-body:      #374151;   /* Body copy */
--color-text-secondary: #6B7280;   /* Meta, timestamps, helper text */
--color-text-tertiary:  #9CA3AF;   /* Placeholders, disabled states */
--color-text-disabled:  #D1D5DB;   /* Truly disabled content */
--color-text-inverse:   #FFFFFF;   /* Text on dark/primary backgrounds */

/* === Primary — Refined Blue === */
/* Not a generic SaaS blue. This sits between indigo and slate — serious, trustworthy. */
--color-primary-50:     #EEF2FF;
--color-primary-100:    #E0E7FF;
--color-primary-200:    #C7D2FE;
--color-primary-300:    #A5B4FC;
--color-primary-400:    #818CF8;
--color-primary-500:    #6366F1;   /* Base primary — interactive elements */
--color-primary-600:    #4F46E5;   /* Hover state */
--color-primary-700:    #4338CA;   /* Active/pressed state */
--color-primary-800:    #3730A3;   /* Dark backgrounds with primary context */
--color-primary-900:    #312E81;

/* Semantic shortcuts */
--color-primary:        var(--color-primary-500);
--color-primary-hover:  var(--color-primary-600);
--color-primary-active: var(--color-primary-700);
--color-primary-subtle: var(--color-primary-50);

/* === Accent — Warm Amber === */
/* Used sparingly: "Today" deadline badges, important callouts, star ratings. */
--color-accent:         #F59E0B;
--color-accent-subtle:  #FEF3C7;
--color-accent-dark:    #D97706;

/* === Sidebar === */
--color-sidebar-bg:     #EEF2F8;   /* Slightly cooler than canvas */
--color-sidebar-active: #1E2939;   /* Near-black for active nav item background */
--color-sidebar-hover:  #E2E8F0;
```

### Semantic Colors — Data States

These are used exclusively for status badges, score pills, and attendance indicators. They are never used for decoration.

```css
/* Success / Submitted / Present */
--color-success-bg:   #F0FDF4;
--color-success-text: #15803D;
--color-success-border:#BBF7D0;

/* Warning / Ongoing / Pending */
--color-warning-bg:   #FFFBEB;
--color-warning-text: #B45309;
--color-warning-border:#FDE68A;

/* Danger / Late / Absent */
--color-danger-bg:    #FFF1F2;
--color-danger-text:  #BE123C;
--color-danger-border:#FECDD3;

/* Neutral / Excused / Draft */
--color-neutral-bg:   #F8FAFC;
--color-neutral-text: #475569;
--color-neutral-border:#E2E8F0;

/* Info / Informational callouts */
--color-info-bg:      #EFF6FF;
--color-info-text:    #1D4ED8;
--color-info-border:  #BFDBFE;
```

### Class Gradient System

Each class card receives one of four gradient identities, assigned by index. These are the only gradients in the system. They use desaturated, refined tones — not the saturated, "Dribbble card" gradients that look like every other EdTech product.

```css
/* Gradient index 0 — Dusk Violet */
--grad-0-from: #6D5FBF;
--grad-0-to:   #4B7BA8;

/* Gradient index 1 — Deep Teal */
--grad-1-from: #1A7FAD;
--grad-1-to:   #2A9D8F;

/* Gradient index 2 — Forest */
--grad-2-from: #2D7D52;
--grad-2-to:   #7A9E3B;

/* Gradient index 3 — Ember */
--grad-3-from: #C2692A;
--grad-3-to:   #C8A227;

/* Usage */
.class-card[data-gradient="0"] { background: linear-gradient(135deg, var(--grad-0-from), var(--grad-0-to)); }
.class-card[data-gradient="1"] { background: linear-gradient(135deg, var(--grad-1-from), var(--grad-1-to)); }
.class-card[data-gradient="2"] { background: linear-gradient(135deg, var(--grad-2-from), var(--grad-2-to)); }
.class-card[data-gradient="3"] { background: linear-gradient(135deg, var(--grad-3-from), var(--grad-3-to)); }
```

### Color Rules

1. **Never use color for emphasis alone.** Pair color with weight, size, or icon to convey meaning.
2. **The primary color is reserved for actions and active states.** It should not appear in decorative headings or background fills on the page canvas.
3. **Avoid alpha transparency for color values** except for shadows and overlays. Use explicit hex values so colors are predictable across rendering contexts.
4. **Dark mode is not in scope for v1.** The palette is calibrated for light mode only. When dark mode is added, it will have its own token set — do not attempt to invert the current palette.

---

## Spacing

Spacing is the most underrated design tool. In a minimalist system, it does the visual work that decoration would otherwise do. Generous spacing signals confidence. Tight spacing signals urgency. Random spacing signals carelessness.

### Base Unit

All spacing derives from a **4px base unit**. Every value in the system is a multiple of 4.

```css
--space-0:   0px;
--space-px:  1px;    /* Only for hairlines/borders, never for padding/margin */
--space-0-5: 2px;    /* Micro-adjustments, badge padding */
--space-1:   4px;    /* Inline element gaps, icon-to-text gaps */
--space-1-5: 6px;    /* Compact badge padding */
--space-2:   8px;    /* Tight internal padding */
--space-3:   12px;   /* Default internal element padding (chips, pills) */
--space-4:   16px;   /* Standard content padding unit */
--space-5:   20px;   /* Slightly generous gaps */
--space-6:   24px;   /* Card internal padding (default) */
--space-7:   28px;   /* Occasional mid-step */
--space-8:   32px;   /* Section gaps within a card */
--space-10:  40px;   /* Large internal gaps, list item spacing */
--space-12:  48px;   /* Between major sections on a page */
--space-14:  56px;   /* Large breathing room */
--space-16:  64px;   /* Page-level top/bottom padding */
--space-20:  80px;   /* Hero sections, prominent empty states */
--space-24:  96px;   /* Maximum content breathing room */
```

### Spacing Application Guide

| Context | Value |
|---|---|
| Between icon and its label | `--space-2` (8px) |
| Inside a button (horizontal) | `--space-4` to `--space-6` |
| Inside a button (vertical) | `--space-2` to `--space-3` |
| Inside a card | `--space-6` (24px) default |
| Between list items in a feed | `--space-0` with `border-bottom` divider |
| Between stacked cards | `--space-4` (16px) |
| Between page sections | `--space-10` to `--space-12` |
| Page horizontal padding (desktop) | `--space-8` (32px) |
| Page horizontal padding (mobile) | `--space-4` (16px) |
| Sidebar padding | `--space-4` horizontal, `--space-3` vertical per item |
| Tab underline offset | `--space-1` below text baseline |

### Spatial Rules

1. **Consistency over precision.** When in doubt between two close values, pick the one that matches surrounding elements rather than the geometrically "correct" one.
2. **Group related things, separate unrelated things.** A 32px gap between a heading and its content is wrong. An 8px gap between the two is also wrong. Find the rhythm.
3. **Never use `margin: auto` for centering content in a flex column.** Use `align-items: center` or explicit padding.
4. **The sidebar nav items use padding, not margin.** This ensures the active state background fills the full item width.

---

## Elevation & Depth

Depth is expressed through shadow alone, never by color shifting the background. The `--color-surface` is always `#FFFFFF` regardless of elevation level. Perceived elevation is created by shadow.

```css
/* No elevation — page canvas, inset areas */
--shadow-none: none;

/* Level 1 — Standard card, default panels */
--shadow-sm: 0 1px 2px rgba(17, 24, 39, 0.05),
             0 1px 4px rgba(17, 24, 39, 0.04);

/* Level 2 — Hovered cards, dropdowns */
--shadow-md: 0 2px 4px rgba(17, 24, 39, 0.04),
             0 4px 12px rgba(17, 24, 39, 0.08);

/* Level 3 — Active cards, date picker popover */
--shadow-lg: 0 4px 8px rgba(17, 24, 39, 0.04),
             0 12px 24px rgba(17, 24, 39, 0.10);

/* Level 4 — Modals, dialogs (if ever used) */
--shadow-xl: 0 8px 16px rgba(17, 24, 39, 0.06),
             0 24px 48px rgba(17, 24, 39, 0.14);

/* Focus ring — not a shadow, but rendered alongside */
--ring-focus: 0 0 0 3px rgba(99, 102, 241, 0.25);
```

### Shadow Rules

1. Never stack multiple elevation levels on the same component.
2. Cards have `--shadow-sm` by default. On hover, transition to `--shadow-md`.
3. The sidebar has no shadow on desktop. On mobile overlay, it uses `--shadow-xl`.
4. Avoid `box-shadow: inset` except for input fields in their default state.

---

## Border Radius

Radius is consistent and deliberate. The system avoids mixing sharp rectangles with pill shapes on the same component.

```css
--radius-none:  0px;     /* Tables, data rows — razor-sharp */
--radius-xs:    3px;     /* File type badges, tiny chips */
--radius-sm:    6px;     /* Buttons (compact), small badges */
--radius-md:    8px;     /* Buttons (default), input fields */
--radius-lg:    12px;    /* Cards (default) */
--radius-xl:    16px;    /* Class header banners, large panels */
--radius-2xl:   20px;    /* Calendar widget, modal containers */
--radius-full:  9999px;  /* Pills (status badges, score badges), avatars */
```

### Radius Rules

1. **Cards always use `--radius-lg` (12px).** No exceptions.
2. **Buttons use `--radius-md` (8px).** The pill-shaped button (`--radius-full`) is reserved for the floating "+ Add Assignment" button in the Calendar header only.
3. **Never round table rows.** Data grids are sharp-cornered by nature. The container that holds a table may be rounded; the rows inside are not.
4. **Avatars are always `--radius-full` (circles).**
5. **Input fields use `--radius-md` (8px).** This matches the button radius, creating visual harmony in forms.

---

## Iconography

Icons are used functionally, never decoratively. Each icon must communicate a specific meaning that would otherwise require a text label.

### Icon System

Use **Lucide Icons** exclusively. It is an open-source, MIT-licensed icon set with consistent stroke widths and a clean, restrained aesthetic that aligns with our design language. It is also tree-shakable — import only what you need.

Icon properties:
```
stroke-width: 1.5      /* Default for UI icons */
stroke-width: 1.25     /* For larger icons (24px+) in headers */
size: 16px             /* Small — nav labels, inline actions */
size: 20px             /* Medium — primary navigation items */
size: 24px             /* Large — empty states, feature illustrations */
```

**Never use filled icons alongside outlined icons.** Choose one style per component context and stay consistent. Lucide is always outlined.

### Icon Color Rules

- Navigation icons: `--color-text-secondary` (inactive), `--color-text-inverse` (active on dark bg)
- Action icons (buttons): inherit from button text color
- Status icons (check, x, clock): inherit from the semantic color of the status
- Decorative-adjacent icons (empty states): `--color-border-strong`, at 24px

### Icon + Label Alignment

```css
.icon-label {
  display: flex;
  align-items: center;
  gap: var(--space-2);   /* 8px between icon and label */
}
```

Never use `vertical-align: middle` for inline icon alignment. Always use flexbox.

---

## Component Design

### Buttons

Three button variants. Nothing more.

**Primary Button** — For the single most important action on a view.
```css
.btn-primary {
  background:    var(--color-primary);
  color:         var(--color-text-inverse);
  border:        none;
  border-radius: var(--radius-md);
  padding:       var(--space-2) var(--space-5);      /* 10px 20px */
  font-family:   var(--font-ui);
  font-size:     var(--text-sm);
  font-weight:   var(--weight-semibold);
  line-height:   var(--leading-tight);
  cursor:        pointer;
  transition:    background 140ms ease, box-shadow 140ms ease, transform 80ms ease;
}
.btn-primary:hover  { background: var(--color-primary-hover); }
.btn-primary:active { background: var(--color-primary-active); transform: translateY(1px); }
.btn-primary:focus-visible { outline: none; box-shadow: var(--ring-focus); }
```

**Secondary / Outlined Button** — For supporting actions alongside a primary.
```css
.btn-secondary {
  background:    transparent;
  color:         var(--color-text-body);
  border:        1px solid var(--color-border);
  border-radius: var(--radius-md);
  padding:       var(--space-2) var(--space-5);
  font-size:     var(--text-sm);
  font-weight:   var(--weight-medium);
  transition:    border-color 140ms ease, background 140ms ease;
}
.btn-secondary:hover { background: var(--color-surface-inset); border-color: var(--color-border-strong); }
```

**Ghost Button** — Lowest-emphasis. Used for destructive actions or tertiary navigation.
```css
.btn-ghost {
  background:    transparent;
  color:         var(--color-text-secondary);
  border:        none;
  padding:       var(--space-2) var(--space-3);
  font-size:     var(--text-sm);
  font-weight:   var(--weight-medium);
  border-radius: var(--radius-sm);
  transition:    background 120ms ease, color 120ms ease;
}
.btn-ghost:hover { background: var(--color-surface-inset); color: var(--color-text-primary); }
```

**Button Size Variants**
```css
/* Compact — for inline table actions */
.btn--sm { padding: var(--space-1) var(--space-3); font-size: var(--text-xs); }

/* Default */
.btn--md { padding: var(--space-2) var(--space-5); font-size: var(--text-sm); }

/* Large — for the welcome banner's CTAs */
.btn--lg { padding: var(--space-3) var(--space-6); font-size: var(--text-base); }
```

**Button Rules**
- There is only ever one Primary button per view or per form.
- Button labels are always sentence case, never all-caps.
- Buttons with icons place the icon to the left of the label with `gap: var(--space-2)`.
- Loading state: replace label text with a subtle spinner, maintain exact button width.
- Disabled state: `opacity: 0.45; cursor: not-allowed;` — never change the background color.

---

### Cards

Cards are the primary surface for grouping related information. They sit on the canvas, separated by their shadow and border rather than by background color difference.

```css
.card {
  background:    var(--color-surface);
  border:        1px solid var(--color-border-subtle);
  border-radius: var(--radius-lg);
  box-shadow:    var(--shadow-sm);
  padding:       var(--space-6);
  transition:    box-shadow 200ms ease;
}

/* Clickable cards (class cards, assignment rows) */
.card--interactive {
  cursor: pointer;
}
.card--interactive:hover {
  box-shadow: var(--shadow-md);
}

/* Inset card — for nested content inside another card */
.card--inset {
  background: var(--color-surface-inset);
  border:     1px solid var(--color-border-subtle);
  box-shadow: none;
}

/* Flat card — no border, used in sidebar panels */
.card--flat {
  border:     none;
  box-shadow: none;
}
```

**Card Rules**
- Card padding is `--space-6` (24px) on all sides. Reduce to `--space-4` on mobile.
- Cards never nest more than one level deep. A card inside a card is the maximum.
- The card's header (title + action) is separated from its content by a `--space-4` gap, not a divider line.
- Never put a card inside a card inside a card.

---

### Form Inputs

Forms must feel precise and trustworthy. Flimsy input styling destroys confidence.

```css
.input {
  width:         100%;
  background:    var(--color-surface-inset);
  border:        1px solid var(--color-border);
  border-radius: var(--radius-md);
  padding:       var(--space-2-5) var(--space-3);   /* ~10px 12px */
  font-family:   var(--font-ui);
  font-size:     var(--text-sm);
  font-weight:   var(--weight-regular);
  color:         var(--color-text-primary);
  line-height:   var(--leading-normal);
  transition:    border-color 140ms ease, box-shadow 140ms ease;
  box-shadow:    inset 0 1px 2px rgba(0,0,0,0.04);
}

.input::placeholder {
  color: var(--color-text-tertiary);
}

.input:hover {
  border-color: var(--color-border-strong);
}

.input:focus {
  outline:      none;
  border-color: var(--color-primary);
  box-shadow:   var(--ring-focus), inset 0 1px 2px rgba(0,0,0,0.04);
  background:   var(--color-surface);
}

.input:disabled {
  opacity:    0.5;
  cursor:     not-allowed;
  background: var(--color-surface-inset);
}
```

**Labels**
```css
.label {
  display:       block;
  font-size:     var(--text-sm);
  font-weight:   var(--weight-medium);
  color:         var(--color-text-primary);
  margin-bottom: var(--space-1-5);
}

.label-helper {
  display:    block;
  font-size:  var(--text-xs);
  color:      var(--color-text-secondary);
  margin-top: var(--space-1);
}
```

---

### Navigation Sidebar

The sidebar is a vertical rhythm of navigation items. It should feel invisible when not needed and immediate when consulted.

```css
.sidebar {
  width:          200px;
  min-height:     100vh;
  background:     var(--color-sidebar-bg);
  display:        flex;
  flex-direction: column;
  padding:        var(--space-5) var(--space-3);
  position:       fixed;
  top:            0;
  left:           0;
  border-right:   1px solid var(--color-border-subtle);
}

/* Logo area */
.sidebar-logo {
  padding:        var(--space-2) var(--space-2);
  margin-bottom:  var(--space-6);
  display:        flex;
  align-items:    center;
  gap:            var(--space-2);
}

/* Nav items group */
.sidebar-nav {
  flex:           1;
  display:        flex;
  flex-direction: column;
  gap:            var(--space-0-5);
}

/* Individual nav item */
.nav-item {
  display:        flex;
  align-items:    center;
  gap:            var(--space-2);
  padding:        var(--space-2) var(--space-3);
  border-radius:  var(--radius-md);
  font-size:      var(--text-sm);
  font-weight:    var(--weight-medium);
  color:          var(--color-text-secondary);
  text-decoration:none;
  transition:     background 120ms ease, color 120ms ease;
}

.nav-item:hover {
  background: var(--color-sidebar-hover);
  color:      var(--color-text-primary);
}

/* Active state */
.nav-item.active {
  background: var(--color-sidebar-active);
  color:      var(--color-text-inverse);
}

.nav-item.active svg {
  stroke: var(--color-text-inverse);
}

/* Sign out — pinned to bottom */
.sidebar-footer {
  padding-top:  var(--space-4);
  border-top:   1px solid var(--color-border-subtle);
  margin-top:   auto;
}
```

---

### Tab Navigation

Used inside Class Detail pages. Must scroll horizontally on mobile without showing a scrollbar.

```css
.tab-nav {
  display:          flex;
  gap:              var(--space-1);
  border-bottom:    1px solid var(--color-border-subtle);
  overflow-x:       auto;
  scrollbar-width:  none;
  -ms-overflow-style: none;
}
.tab-nav::-webkit-scrollbar { display: none; }

.tab {
  padding:          var(--space-2) var(--space-4);
  font-size:        var(--text-sm);
  font-weight:      var(--weight-medium);
  color:            var(--color-text-secondary);
  border-bottom:    2px solid transparent;
  white-space:      nowrap;
  cursor:           pointer;
  transition:       color 140ms ease, border-color 140ms ease;
  margin-bottom:    -1px;  /* Sits on top of the nav's border-bottom */
}

.tab:hover {
  color: var(--color-text-primary);
}

.tab.active {
  color:        var(--color-primary);
  border-color: var(--color-primary);
  font-weight:  var(--weight-semibold);
}
```

---

### Status Badges

Badges communicate state. They use full-pill radius and are always paired with a meaningful label. Never use a badge purely for decoration.

```css
.badge {
  display:       inline-flex;
  align-items:   center;
  gap:           var(--space-1);
  padding:       var(--space-0-5) var(--space-2-5);
  border-radius: var(--radius-full);
  font-family:   var(--font-ui);
  font-size:     var(--text-xs);
  font-weight:   var(--weight-semibold);
  line-height:   1;
  white-space:   nowrap;
  letter-spacing: var(--tracking-wide);
}

.badge--submitted, .badge--present {
  background: var(--color-success-bg);
  color:      var(--color-success-text);
}

.badge--ongoing, .badge--pending {
  background: var(--color-warning-bg);
  color:      var(--color-warning-text);
}

.badge--late, .badge--absent {
  background: var(--color-danger-bg);
  color:      var(--color-danger-text);
}

.badge--excused, .badge--draft, .badge--neutral {
  background: var(--color-neutral-bg);
  color:      var(--color-neutral-text);
  border:     1px solid var(--color-border);
}

.badge--professor, .badge--teacher {
  background: var(--color-primary);
  color:      var(--color-text-inverse);
}

.badge--student {
  background:  transparent;
  color:       var(--color-text-secondary);
  border:      1px solid var(--color-border);
}
```

---

### Score Pills

Score pills use background color to communicate performance level. The value inside always uses the monospace font for alignment.

```css
.score-pill {
  display:        inline-flex;
  align-items:    center;
  justify-content:center;
  padding:        var(--space-1) var(--space-2-5);
  border-radius:  var(--radius-full);
  font-family:    var(--font-mono);
  font-size:      var(--text-xs);
  font-weight:    var(--weight-bold);
  min-width:      44px;
}

.score-pill--high {
  background: #DCFCE7;
  color:      #166534;
}

.score-pill--mid {
  background: #FEF3C7;
  color:      #92400E;
}

.score-pill--low {
  background: #FEE2E2;
  color:      #991B1B;
}

.score-pill--pending {
  background: var(--color-neutral-bg);
  color:      var(--color-text-tertiary);
}
```

Score thresholds:
- **High** (≥ 80%): green pill
- **Mid** (50–79%): amber pill
- **Low** (< 50%): red pill
- **Not graded** (`---`): neutral/gray pill

---

### Avatars

```css
.avatar {
  width:         36px;
  height:        36px;
  border-radius: var(--radius-full);
  background:    var(--color-surface-inset);
  object-fit:    cover;
  flex-shrink:   0;
}

.avatar--sm { width: 28px; height: 28px; }
.avatar--lg { width: 48px; height: 48px; }
.avatar--xl { width: 80px; height: 80px; }

/* Online indicator */
.avatar-wrap {
  position: relative;
  display:  inline-flex;
}
.avatar-wrap .status-dot {
  position:      absolute;
  bottom:        1px;
  right:         1px;
  width:         9px;
  height:        9px;
  border-radius: var(--radius-full);
  background:    var(--color-success-text);
  border:        2px solid var(--color-surface);
}
```

---

## Motion & Transitions

Animation should be felt, not seen. If a user notices an animation, it is probably too slow or too dramatic.

### Easing Curves

```css
--ease-standard:  cubic-bezier(0.4, 0, 0.2, 1);   /* Most UI transitions */
--ease-enter:     cubic-bezier(0, 0, 0.2, 1);      /* Elements appearing */
--ease-exit:      cubic-bezier(0.4, 0, 1, 1);      /* Elements disappearing */
--ease-spring:    cubic-bezier(0.34, 1.56, 0.64, 1); /* Subtle springiness for hovers */
```

### Duration Scale

```css
--duration-instant:  80ms;   /* Pressed state feedback */
--duration-fast:     140ms;  /* Hover colors, border colors */
--duration-normal:   200ms;  /* Card shadows, sidebar hover */
--duration-moderate: 280ms;  /* Page transitions, panel slides */
--duration-slow:     400ms;  /* Skeleton loading shimmer */
```

### Permitted Animations

**Page entry (staggered fade-up)**
```css
@keyframes fadeUp {
  from { opacity: 0; transform: translateY(8px); }
  to   { opacity: 1; transform: translateY(0); }
}

.page-enter { animation: fadeUp var(--duration-moderate) var(--ease-enter) both; }
.page-enter:nth-child(1) { animation-delay: 0ms; }
.page-enter:nth-child(2) { animation-delay: 40ms; }
.page-enter:nth-child(3) { animation-delay: 80ms; }
```

**Card hover lift** — `box-shadow` transition only, never `transform: translateY` on cards.

**Sidebar item active transition** — `background` and `color` only.

**Tab indicator slide** — `border-color` transition, `--duration-fast`.

**Skeleton shimmer** (loading state):
```css
@keyframes shimmer {
  from { background-position: -400px 0; }
  to   { background-position: 400px 0; }
}

.skeleton {
  background: linear-gradient(90deg,
    var(--color-surface-inset) 25%,
    #E9EBF0 50%,
    var(--color-surface-inset) 75%
  );
  background-size: 800px 100%;
  animation: shimmer 1.4s ease-in-out infinite;
  border-radius: var(--radius-sm);
}
```

### Motion Rules

1. **Disable all transitions when `prefers-reduced-motion: reduce`.**
   ```css
   @media (prefers-reduced-motion: reduce) {
     *, *::before, *::after {
       animation-duration: 0.01ms !important;
       transition-duration: 0.01ms !important;
     }
   }
   ```
2. Never animate `width`, `height`, or `margin`. These cause layout recalculation.
3. Only animate `opacity`, `transform`, `box-shadow`, `background-color`, `color`, `border-color`.
4. Never use `animation: bounce` or `animation: pulse` on interactive elements.

---

## Responsive Breakpoints

```css
/* Breakpoint tokens */
--bp-mobile:  600px;   /* Below this: mobile layout */
--bp-tablet:  1024px;  /* Between 601px–1024px: tablet layout */
--bp-desktop: 1025px;  /* Above this: desktop layout */

/* Usage (mobile-first) */
/* Base styles: mobile */
.sidebar     { display: none; }
.bottom-nav  { display: flex; }
.main-content { padding: var(--space-4); padding-bottom: 72px; }

/* Tablet */
@media (min-width: 601px) {
  .sidebar     { display: flex; transform: translateX(-200px); }
  .sidebar.open{ transform: translateX(0); }
  .bottom-nav  { display: none; }
  .main-content{ margin-left: 0; padding: var(--space-6); }
}

/* Desktop */
@media (min-width: 1025px) {
  .sidebar      { transform: none; }   /* Always visible */
  .main-content { margin-left: 200px; }
  .sidebar-toggle { display: none; }
}
```

### Content Width Limits

```css
/* Prevent ultra-wide content on large monitors */
.page-container {
  max-width: 1200px;
  margin: 0 auto;
}

/* Content-only zones (forms, profiles) */
.content-narrow {
  max-width: 680px;
}

/* Rich data views (gradebook, member list) */
.content-wide {
  max-width: 960px;
}
```

---

## Empty States

Empty states are moments of opportunity. Design them to guide, not just inform.

Every empty state has:
1. A simple, contextual SVG illustration (monochrome, 80px)
2. A concise heading (Instrument Serif, `--text-2xl`)
3. A one-sentence description (Figtree, `--color-text-secondary`)
4. One primary action button (when action is possible)

```
┌─────────────────────────────────┐
│                                 │
│          [SVG Icon 80px]        │
│                                 │
│    No classes yet               │ ← Instrument Serif, text-2xl
│    Create your first class to   │ ← Figtree, text-sm, text-secondary
│    get started.                 │
│                                 │
│    [ + Create Class ]           │ ← btn-primary, btn--md
│                                 │
└─────────────────────────────────┘
```

---

## Writing Style

Design and writing are inseparable. The copy must match the visual tone.

**Voice:** Direct, warm, uncluttered. Never robotic, never condescending.

| Instead of... | Write... |
|---|---|
| "There are no assignments available at this time." | "No assignments yet." |
| "Please enter a valid email address." | "Enter a valid email." |
| "Your submission was received successfully." | "Submitted." |
| "An error has occurred. Please try again." | "Something went wrong — try again." |
| "Welcome back, Professor Alex!" | "Welcome back, Prof. Alex!" |

**Sentence case everywhere.** The only uppercase text is categorical labels (e.g., TOTAL MEMBERS, YOUR IDENTIFICATION), which use `letter-spacing: var(--tracking-widest)` and `font-size: var(--text-2xs)`.

**Numbers and dates:**
- Scores: always `10/10` format in JetBrains Mono
- Timestamps: relative when recent ("2 hours ago"), absolute when not ("Oct 18")
- Dates: `MMM D, YYYY` (e.g., "Oct 22, 2023") — never `10/22/23`

---

## Accessibility Standards

- **Color contrast:** 4.5:1 minimum for body text; 3:1 for large text (18px+ bold or 24px+ regular)
- **Focus states:** Visible `box-shadow: var(--ring-focus)` on all interactive elements; never `outline: none` without a replacement
- **Touch targets:** Minimum 44×44px for all interactive elements on mobile
- **Motion:** `prefers-reduced-motion` respected globally
- **Screen readers:** All icon-only buttons have `aria-label`; all status badges communicate meaning through text, not just color
- **Forms:** Every input has an associated `<label>` via `for`/`id` — never use `placeholder` as a substitute for a label

---

## Anti-Patterns — What Never to Do

This section is as important as everything above. These are prohibited.

| ❌ Prohibited | ✅ Instead |
|---|---|
| Purple-to-blue gradient hero sections | Flat primary color banners with contrast text |
| Glassmorphism (`backdrop-filter: blur`) | Solid surface colors with defined borders |
| Hover tooltip on every element | Visible labels where space permits; tooltip only for icon-only elements |
| Three or more font families | Instrument Serif + Figtree + JetBrains Mono only |
| `font-weight: 900` or `font-weight: 300` | Stay within 400–700 |
| `box-shadow` with `spread` values over 4px | Keep shadow tight and directional |
| Background images behind text without sufficient contrast overlay | Always test contrast; prefer solid surfaces |
| Rounded corners on table rows | Tables are always sharp |
| Animated entrance on every element | Page-level stagger only; components load instantly |
| `!important` in component styles | Specificity management via BEM and scoped styles |
| Inline `style=""` attributes for layout | CSS classes always |
| More than one `btn-primary` per view | One primary action per view |
| Color-only error states (red border alone) | Red border + error icon + helper text below field |
| `cursor: pointer` on non-interactive elements | Only on clickable things |
| Empty `alt=""` on meaningful images | Describe the image's purpose |

---

## Design System Tokens — Complete Reference

For implementation: import or declare these as CSS custom properties in `:root` in `app.css`. All component styles reference only these tokens — never raw values.

```css
:root {
  /* Typography */
  --font-display:  'Instrument Serif', Georgia, serif;
  --font-ui:       'Figtree', system-ui, sans-serif;
  --font-mono:     'JetBrains Mono', 'Courier New', monospace;

  /* Type Scale */
  --text-2xs: 0.625rem; --text-xs: 0.75rem; --text-sm: 0.875rem;
  --text-base: 1rem; --text-md: 1.125rem; --text-lg: 1.25rem;
  --text-xl: 1.5rem; --text-2xl: 1.875rem; --text-3xl: 2.25rem; --text-4xl: 3rem;

  /* Weights */
  --weight-regular: 400; --weight-medium: 500;
  --weight-semibold: 600; --weight-bold: 700;

  /* Leading */
  --leading-tight: 1.2; --leading-snug: 1.35;
  --leading-normal: 1.5; --leading-relaxed: 1.65;

  /* Tracking */
  --tracking-tight: -0.02em; --tracking-normal: 0em;
  --tracking-wide: 0.04em; --tracking-widest: 0.08em;

  /* Spacing */
  --space-0: 0px; --space-px: 1px; --space-0-5: 2px; --space-1: 4px;
  --space-1-5: 6px; --space-2: 8px; --space-2-5: 10px; --space-3: 12px;
  --space-4: 16px; --space-5: 20px; --space-6: 24px; --space-7: 28px;
  --space-8: 32px; --space-10: 40px; --space-12: 48px; --space-14: 56px;
  --space-16: 64px; --space-20: 80px; --space-24: 96px;

  /* Radius */
  --radius-none: 0px; --radius-xs: 3px; --radius-sm: 6px;
  --radius-md: 8px; --radius-lg: 12px; --radius-xl: 16px;
  --radius-2xl: 20px; --radius-full: 9999px;

  /* Shadows */
  --shadow-none: none;
  --shadow-sm: 0 1px 2px rgba(17,24,39,0.05), 0 1px 4px rgba(17,24,39,0.04);
  --shadow-md: 0 2px 4px rgba(17,24,39,0.04), 0 4px 12px rgba(17,24,39,0.08);
  --shadow-lg: 0 4px 8px rgba(17,24,39,0.04), 0 12px 24px rgba(17,24,39,0.10);
  --shadow-xl: 0 8px 16px rgba(17,24,39,0.06), 0 24px 48px rgba(17,24,39,0.14);
  --ring-focus: 0 0 0 3px rgba(99,102,241,0.25);

  /* Colors — Backgrounds */
  --color-canvas: #F7F8FA; --color-surface: #FFFFFF;
  --color-surface-inset: #F1F3F6;

  /* Colors — Borders */
  --color-border-subtle: #EAECF0; --color-border: #D5D9E2;
  --color-border-strong: #B0B8C8;

  /* Colors — Text */
  --color-text-primary: #111827; --color-text-body: #374151;
  --color-text-secondary: #6B7280; --color-text-tertiary: #9CA3AF;
  --color-text-disabled: #D1D5DB; --color-text-inverse: #FFFFFF;

  /* Colors — Primary */
  --color-primary: #6366F1; --color-primary-hover: #4F46E5;
  --color-primary-active: #4338CA; --color-primary-subtle: #EEF2FF;

  /* Colors — Accent */
  --color-accent: #F59E0B; --color-accent-subtle: #FEF3C7;

  /* Colors — Sidebar */
  --color-sidebar-bg: #EEF2F8; --color-sidebar-active: #1E2939;
  --color-sidebar-hover: #E2E8F0;

  /* Colors — Semantic */
  --color-success-bg: #F0FDF4; --color-success-text: #15803D;
  --color-warning-bg: #FFFBEB; --color-warning-text: #B45309;
  --color-danger-bg:  #FFF1F2; --color-danger-text:  #BE123C;
  --color-neutral-bg: #F8FAFC; --color-neutral-text: #475569;
  --color-info-bg:    #EFF6FF; --color-info-text:    #1D4ED8;

  /* Gradients */
  --grad-0-from: #6D5FBF; --grad-0-to: #4B7BA8;
  --grad-1-from: #1A7FAD; --grad-1-to: #2A9D8F;
  --grad-2-from: #2D7D52; --grad-2-to: #7A9E3B;
  --grad-3-from: #C2692A; --grad-3-to: #C8A227;

  /* Easing */
  --ease-standard: cubic-bezier(0.4, 0, 0.2, 1);
  --ease-enter:    cubic-bezier(0, 0, 0.2, 1);
  --ease-exit:     cubic-bezier(0.4, 0, 1, 1);
  --ease-spring:   cubic-bezier(0.34, 1.56, 0.64, 1);

  /* Duration */
  --duration-instant:  80ms; --duration-fast: 140ms;
  --duration-normal:  200ms; --duration-moderate: 280ms;
  --duration-slow:    400ms;

  /* Breakpoints (for reference — use in @media queries) */
  --bp-mobile:  600px;
  --bp-tablet:  1024px;
  --bp-desktop: 1025px;
}
```

---

*This document is a living guide. As the product evolves, update it — but never add without reason, and never remove without consequence.*