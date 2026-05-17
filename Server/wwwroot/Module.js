/* Module Script */
var GIBS = GIBS || {};

GIBS.SiteStripe = {
};

// Initialize carousels when page loads
document.addEventListener('DOMContentLoaded', function() {
    var carousels = document.querySelectorAll('.carousel');
    carousels.forEach(function(carouselElement) {
        if (carouselElement.id === 'gibsCarousel') {
            // Initialize Bootstrap carousel if available
            if (typeof bootstrap !== 'undefined') {
                new bootstrap.Carousel(carouselElement, {
                    interval: 5000,
                    wrap: true
                });
            }
        }
    });
});