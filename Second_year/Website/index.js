let header = document.querySelector("header");
window.addEventListener("scroll", 
    function() {
        header.classList.toggle("sticky", this.window.scrollY > 0);
    }
)

let menu = document.querySelector('#menu-icon');
let navmenu = document.querySelector('.nav-menu');

menu.onclick = () => {
    menu.classList.toggle('bx-x');
    navmenu.classList.toggle('open');   
}

// Buying forms
document.getElementById('purchase-form').addEventListener('submit', function(event) {
    event.preventDefault();
    const name = document.getElementById('name').value;
    alert(`${name}, благодарим за поръчката!`);
    this.reset();
});

// Forms for review
document.getElementById('review-form').addEventListener('submit', function(event) {
    event.preventDefault();
    const rating = document.getElementById('rating').value;
    const comment = document.getElementById('comment').value;
    const reviews = document.getElementById('reviews');

    // Insert new review
    const reviewCard = document.createElement('div');
    reviewCard.classList.add('review-card');
    const reviewHeader = document.createElement('div');
    reviewHeader.classList.add('review-header');
    const reviewText = document.createElement('p');
    reviewText.textContent = comment;
    const stars = document.createElement('div');
    stars.classList.add('stars');
    let starsContent = '★'.repeat(rating) + '☆'.repeat(5 - rating);
    stars.innerHTML = `<span>${starsContent}</span>`;

    reviewHeader.appendChild(reviewText);
    reviewHeader.appendChild(stars);
    reviewCard.appendChild(reviewHeader);
    reviews.insertBefore(reviewCard, reviews.firstChild);

    this.reset();
});
