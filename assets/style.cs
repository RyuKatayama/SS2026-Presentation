/* ===================================
   SS2026 Presentation - Unified Styles
   組込みシステム開発における生成AI活用の可能性
   ================================= */

:root {
    /* Color Palette */
    --primary-blue: #0066CC;
    --secondary-blue: #004A99;
    --accent-orange: #FF6B35;
    --light-blue: #E6F2FF;
    --dark-slate: #1E293B;
    --medium-gray: #64748B;
    --success-green: #10B981;
    --warning-yellow: #F59E0B;
    --warning-red: #EF4444;
    --text-dark: #1F2937;
    --background: #FFFFFF;
    --light-gray: #F8FAFC;

    /* Spacing System */
    --spacing-xs: 0.5rem;
    --spacing-sm: 1rem;
    --spacing-md: 2rem;
    --spacing-lg: 3rem;
    --spacing-xl: 4rem;

    /* Typography Scale */
    --font-size-sm: 0.875rem;
    --font-size-base: 1rem;
    --font-size-lg: 1.125rem;
    --font-size-xl: 1.25rem;
    --font-size-2xl: 1.5rem;
    --font-size-3xl: 2rem;
    --font-size-4xl: 2.5rem;

    /* Layout Constants */
    --max-width: 1200px;
    --header-height: 80px;
    --footer-height: 60px;
}

/* ===============================
   Base Styles
   =============================== */

* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

html {
    font-size: 16px;
    scroll-behavior: smooth;
}

body {
    font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
    background: linear-gradient(135deg, var(--light-gray) 0%, #E2E8F0 100%);
    color: var(--text-dark);
    line-height: 1.6;
    min-height: 100vh;
    overflow-x: hidden;
}

/* ===============================
   Layout Components
   =============================== */

.slide-container {
    max-width: var(--max-width);
    margin: 0 auto;
    min-height: calc(100vh - var(--header-height) - var(--footer-height));
    display: flex;
    flex-direction: column;
    padding: calc(var(--header-height) + var(--spacing-md)) var(--spacing-md) calc(var(--footer-height) + var(--spacing-md));
}

.slide-header {
    text-align: center;
    margin-bottom: var(--spacing-lg);
    animation: slideInDown 0.8s ease-out;
}

.slide-title {
    font-size: clamp(var(--font-size-3xl), 5vw, var(--font-size-4xl));
    font-weight: 700;
    color: var(--text-dark);
    margin-bottom: var(--spacing-sm);
    letter-spacing: -0.02em;
    line-height: 1.1;
}

.slide-subtitle {
    font-size: clamp(var(--font-size-lg), 3vw, var(--font-size-xl));
    color: var(--medium-gray);
    font-weight: 400;
    line-height: 1.4;
}

.slide-content {
    flex: 1;
    display: flex;
    flex-direction: column;
    gap: var(--spacing-md);
    animation: fadeInUp 0.8s ease-out 0.2s both;
}

/* ===============================
   Navigation Components
   =============================== */

.nav-header {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    height: var(--header-height);
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-bottom: 1px solid #E2E8F0;
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 0 var(--spacing-md);
    z-index: 1000;
    transition: all 0.3s ease;
}

.nav-title {
    font-size: var(--font-size-lg);
    font-weight: 600;
    color: var(--text-dark);
    text-decoration: none;
}

.nav-title:hover {
    color: var(--primary-blue);
}

.nav-controls {
    display: flex;
    align-items: center;
    gap: var(--spacing-sm);
}

.progress-info {
    font-family: 'JetBrains Mono', monospace;
    font-size: var(--font-size-sm);
    color: var(--medium-gray);
    background: var(--light-gray);
    padding: var(--spacing-xs) var(--spacing-sm);
    border-radius: 20px;
    border: 1px solid #E2E8F0;
}

.nav-footer {
    position: fixed;
    bottom: 0;
    left: 0;
    right: 0;
    height: var(--footer-height);
    background: rgba(255, 255, 255, 0.95);
    backdrop-filter: blur(10px);
    border-top: 1px solid #E2E8F0;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: var(--spacing-md);
    z-index: 1000;
}

.nav-button {
    background: var(--primary-blue);
    color: white;
    border: none;
    padding: var(--spacing-xs) var(--spacing-md);
    border-radius: 25px;
    font-weight: 600;
    cursor: pointer;
    transition: all 0.3s ease;
    font-size: var(--font-size-sm);
    text-decoration: none;
    display: inline-flex;
    align-items: center;
    gap: var(--spacing-xs);
    min-width: 100px;
    justify-content: center;
}

.nav-button:hover {
    background: var(--secondary-blue);
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0,102,204,0.3);
}

.nav-button:disabled,
.nav-button.disabled {
    background: var(--medium-gray);
    cursor: not-allowed;
    transform: none;
    box-shadow: none;
}

.nav-button.secondary {
    background: var(--accent-orange);
}

.nav-button.secondary:hover {
    background: #E55A2B;
    box-shadow: 0 4px 12px rgba(255,107,53,0.3);
}

.nav-button.outline {
    background: transparent;
    color: var(--primary-blue);
    border: 2px solid var(--primary-blue);
}

.nav-button.outline:hover {
    background: var(--primary-blue);
    color: white;
}

/* Progress Bar */
.progress-bar {
    position: fixed;
    bottom: var(--footer-height);
    left: 0;
    height: 4px;
    background: linear-gradient(90deg, var(--primary-blue), var(--accent-orange));
    transition: width 0.3s ease;
    z-index: 1001;
}

/* ===============================
   Content Components
   =============================== */

.content-grid {
    display: grid;
    gap: var(--spacing-md);
    margin: var(--spacing-md) 0;
}

.content-grid.two-col {
    grid-template-columns: repeat(auto-fit, minmax(400px, 1fr));
}

.content-grid.three-col {
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
}

.content-card {
    background: var(--background);
    padding: var(--spacing-md);
    border-radius: 16px;
    box-shadow: 0 8px 24px rgba(0,0,0,0.08);
    border: 2px solid transparent;
    transition: all 0.3s ease;
    animation: fadeInUp 0.6s ease-out both;
}

.content-card:hover {
    transform: translateY(-4px);
    box-shadow: 0 20px 40px rgba(0,0,0,0.12);
    border-color: var(--primary-blue);
}

.card-header {
    display: flex;
    align-items: center;
    gap: var(--spacing-sm);
    margin-bottom: var(--spacing-sm);
}

.card-icon {
    width: 3rem;
    height: 3rem;
    border-radius: 12px;
    background: var(--primary-blue);
    color: white;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: var(--font-size-xl);
    font-weight: 700;
    flex-shrink: 0;
}

.card-title {
    font-size: var(--font-size-xl);
    font-weight: 600;
    color: var(--text-dark);
}

.card-content {
    color: var(--medium-gray);
    line-height: 1.6;
}

/* ===============================
   Special Card Types
   =============================== */

.hero-card {
    background: linear-gradient(135deg, var(--primary-blue), var(--secondary-blue));
    color: white;
    text-align: center;
    position: relative;
    overflow: hidden;
    border: none;
    padding: var(--spacing-xl);
}

.hero-card::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: radial-gradient(circle at 30% 20%, rgba(255,255,255,0.1) 0%, transparent 50%);
}

.hero-card .card-content,
.hero-card .card-title {
    color: white;
    position: relative;
    z-index: 1;
}

.metric-card {
    background: linear-gradient(135deg, var(--success-green), #059669);
    color: white;
    text-align: center;
    padding: var(--spacing-lg) var(--spacing-md);
    border: none;
    position: relative;
    overflow: hidden;
}

.metric-card::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: radial-gradient(circle at 30% 20%, rgba(255,255,255,0.15) 0%, transparent 50%);
}

.metric-number {
    font-size: clamp(2.5rem, 8vw, 4rem);
    font-weight: 800;
    font-family: 'JetBrains Mono', monospace;
    margin-bottom: var(--spacing-xs);
    text-shadow: 2px 2px 4px rgba(0,0,0,0.2);
    position: relative;
    z-index: 1;
}

.metric-label {
    font-size: var(--font-size-xl);
    font-weight: 500;
    opacity: 0.9;
    position: relative;
    z-index: 1;
}

/* ===============================
   Interactive Elements
   =============================== */

.expandable-section {
    margin: var(--spacing-md) 0;
}

.expand-trigger {
    background: var(--light-blue);
    border: 2px solid var(--primary-blue);
    border-radius: 12px;
    padding: var(--spacing-md);
    cursor: pointer;
    transition: all 0.3s ease;
    display: flex;
    justify-content: space-between;
    align-items: center;
    font-weight: 600;
    color: var(--text-dark);
    font-size: var(--font-size-lg);
    width: 100%;
}

.expand-trigger:hover {
    background: var(--primary-blue);
    color: white;
    transform: translateY(-2px);
}

.expand-icon {
    font-size: var(--font-size-xl);
    transition: transform 0.3s ease;
}

.expand-trigger.expanded .expand-icon {
    transform: rotate(180deg);
}

.expand-content {
    max-height: 0;
    overflow: hidden;
    transition: max-height 0.5s ease, padding 0.3s ease;
    background: var(--light-gray);
    border-radius: 0 0 12px 12px;
}

.expand-content.expanded {
    max-height: 2000px;
    padding: var(--spacing-md);
}

/* ===============================
   Data Visualization
   =============================== */

.data-table {
    background: var(--background);
    border-radius: 16px;
    overflow: hidden;
    box-shadow: 0 8px 24px rgba(0,0,0,0.08);
    border: 1px solid #E2E8F0;
    margin: var(--spacing-md) 0;
    width: 100%;
}

.table-header {
    background: linear-gradient(90deg, var(--dark-slate), #334155);
    color: white;
    padding: var(--spacing-md);
    font-weight: 600;
    font-size: var(--font-size-lg);
}

.table-row {
    padding: var(--spacing-md);
    border-bottom: 1px solid #E2E8F0;
    transition: all 0.2s ease;
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
    gap: var(--spacing-sm);
    align-items: center;
}

.table-row:hover {
    background: var(--light-gray);
    transform: translateX(4px);
}

.table-row:last-child {
    border-bottom: none;
}

/* V字プロセス専用スタイル */
.v-process-visual {
    background: var(--light-gray);
    border-radius: 20px;
    padding: var(--spacing-lg);
    margin: var(--spacing-md) 0;
    position: relative;
}

.v-shape {
    display: grid;
    grid-template-columns: 1fr 100px 1fr;
    gap: var(--spacing-md);
    align-items: center;
    margin: var(--spacing-md) 0;
}

.v-center {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: var(--spacing-sm);
}

.v-symbol {
    font-size: 4rem;
    font-weight: 700;
    color: var(--primary-blue);
    text-shadow: 2px 2px 4px rgba(0,102,204,0.3);
}

.process-steps {
    display: flex;
    flex-direction: column;
    gap: var(--spacing-sm);
}

.process-step {
    background: var(--background);
    padding: var(--spacing-md);
    border-radius: 12px;
    border: 2px solid transparent;
    transition: all 0.3s ease;
    position: relative;
}

.process-step:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 16px rgba(0,0,0,0.1);
}

.step-early-effect {
    border-color: var(--success-green);
    background: linear-gradient(135deg, rgba(16, 185, 129, 0.05), rgba(16, 185, 129, 0.1));
}

.step-medium-effect {
    border-color: var(--warning-yellow);
    background: linear-gradient(135deg, rgba(245, 158, 11, 0.05), rgba(245, 158, 11, 0.1));
}

.step-long-term {
    border-color: var(--warning-red);
    background: linear-gradient(135deg, rgba(239, 68, 68, 0.05), rgba(239, 68, 68, 0.1));
}

/* 3層構造専用スタイル */
.layer-framework {
    display: flex;
    flex-direction: column;
    gap: var(--spacing-md);
    margin: var(--spacing-lg) 0;
}

.framework-layer {
    background: var(--background);
    border-radius: 16px;
    padding: var(--spacing-md);
    box-shadow: 0 8px 24px rgba(0,0,0,0.08);
    border: 2px solid transparent;
    transition: all 0.3s ease;
    cursor: pointer;
    position: relative;
}

.framework-layer:hover {
    transform: translateY(-4px);
    box-shadow: 0 20px 40px rgba(0,0,0,0.15);
}

.layer-3 { 
    border-color: var(--primary-blue);
    background: linear-gradient(135deg, rgba(0,102,204,0.05), rgba(0,102,204,0.1));
}
.layer-2 { 
    border-color: var(--accent-orange);
    background: linear-gradient(135deg, rgba(255,107,53,0.05), rgba(255,107,53,0.1));
}
.layer-1 { 
    border-color: var(--dark-slate);
    background: linear-gradient(135deg, rgba(30,41,59,0.05), rgba(30,41,59,0.1));
}

.layer-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: var(--spacing-sm);
}

.layer-number {
    width: 3rem;
    height: 3rem;
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    font-weight: 700;
    font-size: var(--font-size-xl);
    color: white;
}

.layer-3 .layer-number { background: var(--primary-blue); }
.layer-2 .layer-number { background: var(--accent-orange); }
.layer-1 .layer-number { background: var(--dark-slate); }

/* ===============================
   Special Layouts
   =============================== */

.title-slide .slide-container {
    background: linear-gradient(135deg, var(--primary-blue), var(--secondary-blue));
    color: white;
    text-align: center;
    display: flex;
    flex-direction: column;
    justify-content: center;
    min-height: 100vh;
    padding: var(--spacing-lg);
}

.title-slide .slide-title {
    color: white;
    font-size: clamp(2.5rem, 6vw, 3.5rem);
}

.title-slide .slide-subtitle {
    color: rgba(255,255,255,0.9);
    font-size: clamp(1.2rem, 4vw, 1.8rem);
}

.conclusion-slide .slide-container {
    background: linear-gradient(135deg, var(--success-green), #059669);
    color: white;
}

.conclusion-slide .slide-title,
.conclusion-slide .slide-subtitle {
    color: white;
}

/* ===============================
   Lists & Typography
   =============================== */

.styled-list {
    list-style: none;
    padding: 0;
}

.styled-list li {
    margin-bottom: 0.75rem;
    padding-left: var(--spacing-md);
    position: relative;
    color: var(--text-dark);
}

.styled-list li::before {
    content: '▶';
    position: absolute;
    left: 0;
    color: var(--primary-blue);
    font-weight: 700;
}

/* Code blocks */
.code-block {
    background: var(--dark-slate);
    color: #E2E8F0;
    padding: var(--spacing-md);
    border-radius: 12px;
    font-family: 'JetBrains Mono', monospace;
    font-size: var(--font-size-sm);
    line-height: 1.6;
    overflow-x: auto;
    margin: var(--spacing-sm) 0;
    border: 1px solid #334155;
}

.code-comment { color: #94A3B8; }
.code-keyword { color: #38BDF8; }
.code-string { color: #84CC16; }

/* ===============================
   Animations
   =============================== */

@keyframes fadeInUp {
    from {
        opacity: 0;
        transform: translateY(30px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}

@keyframes slideInDown {
    from {
        opacity: 0;
        transform: translateY(-30px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}

@keyframes slideIn {
    from {
        opacity: 0;
        transform: translateX(-30px);
    }
    to {
        opacity: 1;
        transform: translateX(0);
    }
}

@keyframes float {
    0%, 100% { transform: translateY(0px); }
    50% { transform: translateY(-10px); }
}

@keyframes pulse {
    0%, 100% { transform: scale(1); }
    50% { transform: scale(1.05); }
}

/* Animation Classes */
.animate-fade-in {
    animation: fadeInUp 0.8s ease-out;
}

.animate-slide-in {
    animation: slideIn 0.6s ease-out;
}

.animate-float {
    animation: float 3s ease-in-out infinite;
}

.animate-pulse {
    animation: pulse 2s infinite;
}

/* Stagger Delays */
.stagger-1 { animation-delay: 0.1s; }
.stagger-2 { animation-delay: 0.2s; }
.stagger-3 { animation-delay: 0.3s; }
.stagger-4 { animation-delay: 0.4s; }

/* ===============================
   Responsive Design
   =============================== */

@media (max-width: 768px) {
    :root {
        --spacing-md: 1rem;
        --spacing-lg: 2rem;
        --header-height: 60px;
        --footer-height: 50px;
    }

    .slide-container {
        padding: calc(var(--header-height) + var(--spacing-sm)) var(--spacing-sm) calc(var(--footer-height) + var(--spacing-sm));
    }

    .content-grid.two-col,
    .content-grid.three-col {
        grid-template-columns: 1fr;
    }

    .nav-header,
    .nav-footer {
        padding: 0 var(--spacing-sm);
    }

    .nav-controls {
        gap: var(--spacing-xs);
    }

    .nav-button {
        padding: var(--spacing-xs) var(--spacing-sm);
        font-size: var(--font-size-sm);
        min-width: 80px;
    }

    .table-row {
        grid-template-columns: 1fr;
    }

    .card-header {
        flex-direction: column;
        text-align: center;
        gap: var(--spacing-xs);
    }

    .v-shape {
        grid-template-columns: 1fr;
    }

    .v-center {
        order: 1;
    }
}

/* ===============================
   Print Styles
   =============================== */

@media print {
    .nav-header,
    .nav-footer,
    .progress-bar {
        display: none;
    }

    .slide-container {
        padding: var(--spacing-md);
        max-width: none;
        min-height: auto;
    }

    .content-card {
        break-inside: avoid;
        box-shadow: none;
        border: 1px solid #ccc;
    }

    body {
        background: white;
    }

    .hero-card,
    .title-slide .slide-container,
    .conclusion-slide .slide-container {
        background: white !important;
        color: var(--text-dark) !important;
    }

    .hero-card .card-title,
    .hero-card .card-content,
    .title-slide .slide-title,
    .title-slide .slide-subtitle,
    .conclusion-slide .slide-title {
        color: var(--text-dark) !important;
    }
}

/* ===============================
   Utility Classes
   =============================== */

.text-center { text-align: center; }
.text-left { text-align: left; }
.text-right { text-align: right; }

.font-weight-bold { font-weight: 700; }
.font-weight-semibold { font-weight: 600; }
.font-weight-medium { font-weight: 500; }

.text-primary { color: var(--primary-blue); }
.text-success { color: var(--success-green); }
.text-warning { color: var(--warning-yellow); }
.text-danger { color: var(--warning-red); }
.text-muted { color: var(--medium-gray); }

.bg-primary { background-color: var(--primary-blue); }
.bg-success { background-color: var(--success-green); }
.bg-warning { background-color: var(--warning-yellow); }
.bg-danger { background-color: var(--warning-red); }
.bg-light { background-color: var(--light-gray); }

.border-primary { border-color: var(--primary-blue); }
.border-success { border-color: var(--success-green); }
.border-warning { border-color: var(--warning-yellow); }
.border-danger { border-color: var(--warning-red); }

.mb-0 { margin-bottom: 0; }
.mb-1 { margin-bottom: var(--spacing-xs); }
.mb-2 { margin-bottom: var(--spacing-sm); }
.mb-3 { margin-bottom: var(--spacing-md); }
.mb-4 { margin-bottom: var(--spacing-lg); }

.mt-0 { margin-top: 0; }
.mt-1 { margin-top: var(--spacing-xs); }
.mt-2 { margin-top: var(--spacing-sm); }
.mt-3 { margin-top: var(--spacing-md); }
.mt-4 { margin-top: var(--spacing-lg); }

.hidden { display: none; }
.visible { display: block; }
