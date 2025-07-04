﻿document.addEventListener("DOMContentLoaded", function () {
    var currentPath = window.location.pathname.toLowerCase();
    var navLinks = document.querySelectorAll('.navbar-nav .nav-link');

    navLinks.forEach(function (link) {
        var linkPath = link.getAttribute('href').toLowerCase();

        if (currentPath === linkPath || currentPath.startsWith(linkPath + "/")) {
            link.classList.remove('nav-link', 'text-primary');
            link.classList.add('btn', 'btn-primary', 'rounded-4');
        } else {
            link.classList.remove('btn', 'btn-primary', 'rounded-4');
            link.classList.add('nav-link', 'text-primary');
        }
    });
});