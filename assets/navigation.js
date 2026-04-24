/**
 * SS2026 Presentation Navigation System
 * 組込みシステム開発における生成AI活用の可能性
 * 
 * Handles navigation between individual HTML slide files
 */

class PresentationNavigation {
    constructor() {
        this.totalSlides = 25;
        this.currentSlide = this.getCurrentSlideNumber();
        this.init();
    }

    /**
     * Initialize the navigation system
     */
    init() {
        this.updateProgressBar();
        this.updateNavigationButtons();
        this.setupKeyboardNavigation();
        this.setupTouchNavigation();
        this.setupExpandableElements();
        this.initializeAnimations();
        
        // Display slide info in console
        console.log(`SS2026 Presentation - Slide ${this.currentSlide} of ${this.totalSlides}`);
    }

    /**
     * Get current slide number from URL
     */
    getCurrentSlideNumber() {
        const path = window.location.pathname;
        
        // Handle index page
        if (path.includes('index.html') || path.endsWith('/')) {
            return 0; // Index page
        }
        
        // Extract slide number from filename (e.g., slide05.html -> 5)
        const match = path.match(/slide(\d{2})\.html/);
        if (match) {
            return parseInt(match[1], 10);
        }
        
        return 1; // Default to slide 1
    }

    /**
     * Navigate to specific slide
     */
    goToSlide(slideNumber) {
        if (slideNumber < 0 || slideNumber > this.totalSlides) {
            return false;
        }

        let targetFile;
        if (slideNumber === 0) {
            targetFile = 'index.html';
        } else {
            targetFile = `slide${slideNumber.toString().padStart(2, '0')}.html`;
        }

        // Add transition effect
        this.addTransitionEffect(() => {
            window.location.href = targetFile;
        });

        return true;
    }

    /**
     * Navigate to next slide
     */
    nextSlide() {
        const nextSlide = this.currentSlide + 1;
        if (nextSlide <= this.totalSlides) {
            return this.goToSlide(nextSlide);
        }
        return false;
    }

    /**
     * Navigate to previous slide
     */
    previousSlide() {
        const prevSlide = this.currentSlide - 1;
        if (prevSlide >= 0) {
            return this.goToSlide(prevSlide);
        }
        return false;
    }

    /**
     * Go to table of contents (index page)
     */
    goToIndex() {
        this.goToSlide(0);
    }

    /**
     * Add transition effect before navigation
     */
    addTransitionEffect(callback) {
        const container = document.querySelector('.slide-container');
        if (container) {
            container.style.transition = 'opacity 0.3s ease, transform 0.3s ease';
            container.style.opacity = '0.8';
            container.style.transform = 'scale(0.98)';
            
            setTimeout(() => {
                callback();
            }, 150);
        } else {
            callback();
        }
    }

    /**
     * Update progress bar
     */
    updateProgressBar() {
        const progressBar = document.getElementById('progressBar');
        if (progressBar && this.currentSlide > 0) {
            const progress = (this.currentSlide / this.totalSlides) * 100;
            progressBar.style.width = `${progress}%`;
        }
    }

    /**
     * Update navigation buttons
     */
    updateNavigationButtons() {
        const prevBtn = document.getElementById('prevBtn');
        const nextBtn = document.getElementById('nextBtn');
        const slideInfo = document.getElementById('slideInfo');

        if (prevBtn) {
            if (this.currentSlide <= 0) {
                prevBtn.disabled = true;
                prevBtn.classList.add('disabled');
            } else {
                prevBtn.disabled = false;
                prevBtn.classList.remove('disabled');
            }
        }

        if (nextBtn) {
            if (this.currentSlide >= this.totalSlides) {
                nextBtn.disabled = true;
                nextBtn.classList.add('disabled');
            } else {
                nextBtn.disabled = false;
                nextBtn.classList.remove('disabled');
            }
        }

        if (slideInfo) {
            if (this.currentSlide === 0) {
                slideInfo.textContent = '目次';
            } else {
                slideInfo.textContent = `${this.currentSlide} / ${this.totalSlides}`;
            }
        }
    }

    /**
     * Setup keyboard navigation
     */
    setupKeyboardNavigation() {
        document.addEventListener('keydown', (e) => {
            switch(e.key) {
                case 'ArrowRight':
                case ' ':
                    e.preventDefault();
                    this.nextSlide();
                    break;
                case 'ArrowLeft':
                    e.preventDefault();
                    this.previousSlide();
                    break;
                case 'Home':
                    e.preventDefault();
                    this.goToSlide(1);
                    break;
                case 'End':
                    e.preventDefault();
                    this.goToSlide(this.totalSlides);
                    break;
                case 't':
                case 'T':
                    e.preventDefault();
                    this.goToIndex();
                    break;
                case 'Escape':
                    e.preventDefault();
                    this.goToIndex();
                    break;
            }
        });
    }

    /**
     * Setup touch navigation for mobile
     */
    setupTouchNavigation() {
        let touchStartX = 0;
        let touchEndX = 0;
        const minSwipeDistance = 50;

        document.addEventListener('touchstart', (e) => {
            touchStartX = e.changedTouches[0].screenX;
        });

        document.addEventListener('touchend', (e) => {
            touchEndX = e.changedTouches[0].screenX;
            const swipeDistance = touchStartX - touchEndX;

            if (Math.abs(swipeDistance) > minSwipeDistance) {
                if (swipeDistance > 0) {
                    // Swipe left - next slide
                    this.nextSlide();
                } else {
                    // Swipe right - previous slide
                    this.previousSlide();
                }
            }
        });
    }

    /**
     * Setup expandable elements
     */
    setupExpandableElements() {
        const expandTriggers = document.querySelectorAll('.expand-trigger');
        
        expandTriggers.forEach(trigger => {
            trigger.addEventListener('click', () => {
                this.toggleExpand(trigger);
            });
        });
    }

    /**
     * Toggle expandable content
     */
    toggleExpand(trigger) {
        const content = trigger.nextElementSibling;
        const isExpanded = trigger.classList.contains('expanded');
        
        if (isExpanded) {
            trigger.classList.remove('expanded');
            content.classList.remove('expanded');
        } else {
            trigger.classList.add('expanded');
            content.classList.add('expanded');
        }
    }

    /**
     * Initialize animations
     */
    initializeAnimations() {
        // Intersection Observer for scroll animations
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.style.opacity = '1';
                    entry.target.style.transform = 'translateY(0)';
                }
            });
        }, {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        });

        // Observe all animated elements
        const animatedElements = document.querySelectorAll(
            '.content-card, .metric-card, .framework-layer, .process-step'
        );
        
        animatedElements.forEach((el, index) => {
            // Initial state
            el.style.opacity = '0';
            el.style.transform = 'translateY(30px)';
            el.style.transition = `opacity 0.6s ease ${index * 0.1}s, transform 0.6s ease ${index * 0.1}s`;
            
            observer.observe(el);
        });

        // Stagger animation for elements with stagger classes
        setTimeout(() => {
            const staggerElements = document.querySelectorAll('[class*="stagger-"]');
            staggerElements.forEach(el => {
                el.style.opacity = '1';
                el.style.transform = 'translateY(0)';
            });
        }, 300);
    }

    /**
     * Utility functions
     */

    /**
     * Show tooltip
     */
    showTooltip(element, message) {
        const tooltip = document.createElement('div');
        tooltip.className = 'tooltip-popup';
        tooltip.textContent = message;
        tooltip.style.cssText = `
            position: absolute;
            background: var(--dark-slate);
            color: white;
            padding: 0.5rem 1rem;
            border-radius: 6px;
            font-size: 0.8rem;
            z-index: 1000;
            pointer-events: none;
            opacity: 0;
            transition: opacity 0.3s ease;
        `;
        
        document.body.appendChild(tooltip);
        
        const rect = element.getBoundingClientRect();
        tooltip.style.left = rect.left + (rect.width / 2) - (tooltip.offsetWidth / 2) + 'px';
        tooltip.style.top = rect.top - tooltip.offsetHeight - 8 + 'px';
        
        setTimeout(() => tooltip.style.opacity = '1', 10);
        
        setTimeout(() => {
            tooltip.style.opacity = '0';
            setTimeout(() => document.body.removeChild(tooltip), 300);
        }, 2000);
    }

    /**
     * Highlight element temporarily
     */
    highlightElement(selector) {
        const element = document.querySelector(selector);
        if (element) {
            const originalStyle = element.style.cssText;
            element.style.cssText += `
                box-shadow: 0 0 0 3px var(--accent-orange) !important;
                transition: box-shadow 0.3s ease !important;
            `;
            
            setTimeout(() => {
                element.style.cssText = originalStyle;
            }, 1000);
        }
    }

    /**
     * Count up animation for numbers
     */
    countUpAnimation(element, target, duration = 2000) {
        const start = 0;
        const range = target - start;
        const startTime = performance.now();
        
        const animate = (currentTime) => {
            const elapsed = currentTime - startTime;
            const progress = Math.min(elapsed / duration, 1);
            const current = Math.floor(start + (range * this.easeOutCubic(progress)));
            
            element.textContent = current.toLocaleString();
            
            if (progress < 1) {
                requestAnimationFrame(animate);
            }
        };
        
        requestAnimationFrame(animate);
    }

    /**
     * Easing function for animations
     */
    easeOutCubic(t) {
        return 1 - Math.pow(1 - t, 3);
    }
}

// Global navigation functions for button onclick events
window.navigateToSlide = function(slideNumber) {
    if (window.navigation) {
        window.navigation.goToSlide(slideNumber);
    }
};

window.navigateNext = function() {
    if (window.navigation) {
        window.navigation.nextSlide();
    }
};

window.navigatePrev = function() {
    if (window.navigation) {
        window.navigation.previousSlide();
    }
};

window.navigateToIndex = function() {
    if (window.navigation) {
        window.navigation.goToIndex();
    }
};

// Additional compatibility functions for slides that use nextSlide() and previousSlide()
window.nextSlide = function() {
    if (window.navigation) {
        window.navigation.nextSlide();
    }
};

window.previousSlide = function() {
    if (window.navigation) {
        window.navigation.previousSlide();
    }
};

// Initialize when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    // Import Google Fonts
    if (!document.querySelector('link[href*="fonts.googleapis.com"]')) {
        const fontLink = document.createElement('link');
        fontLink.href = 'https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700;800&family=JetBrains+Mono:wght@400;500;700&display=swap';
        fontLink.rel = 'stylesheet';
        document.head.appendChild(fontLink);
    }

    // Initialize navigation
    window.navigation = new PresentationNavigation();
    
    // Add smooth scroll behavior
    document.documentElement.style.scrollBehavior = 'smooth';
    
    // Console welcome message
    console.log(`
    🎯 SS2026 Presentation System Loaded
    =====================================
    Keyboard Controls:
    → / Space     : Next slide
    ←             : Previous slide
    Home          : First slide
    End           : Last slide
    T / Escape    : Table of contents
    
    Touch Controls:
    Swipe Left    : Next slide
    Swipe Right   : Previous slide
    
    Current Slide: ${window.navigation.currentSlide}
    Total Slides:  ${window.navigation.totalSlides}
    `);
});

// Export for module use
if (typeof module !== 'undefined' && module.exports) {
    module.exports = PresentationNavigation;
}