// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Code voor de random tekst in de 404 pagina.
function randomtext() {
    var randomtxt = [
        '<a href="https://www.imdb.com/title/tt0120737/">Always remember, Frodo, the page is trying to get back to its master. It wants to be found. Gandalf, The Lord of the Rings: The Fellowship of the Ring (2001)</a>',
        '<a href="https://www.imdb.com/title/tt0088763/">Webpages? Where we&apos;re going, we don&apos;t need webpages. Dr. Emmett Brown, Back to the Future (1985)</a>',
        '<a href="https://www.imdb.com/title/tt0118715/">Where&apos;s the page, Lebowski ? Where&apos;s the page? Blond Thug, The Big Lebowski (1998)</a>',
        '<a href="https://www.imdb.com/title/tt0061512/">What we&apos;ve got here is...failure to communicate. Captain, Cool Hand Luke (1967)</a>',
        '<a href="https://www.imdb.com/title/tt0111161/">Lord! It&apos;s a miracle! Webpage up and vanished like a fart in the wind! Warden Norton, The Shawshank Redemption (1994)</a>',
        '<a href="https://www.imdb.com/title/tt0114369/">What&apos;s on the page ? Detective David Mills, Se7en (1995)</a>',
        '<a href="https://www.imdb.com/title/tt0076759/">This is not the webpage you&apos;re looking for. Obi-Wan Kenobi, Star Wars: Episode IV - A New Hope (1977)</a>',
        '<a href="https://www.imdb.com/title/tt0080339/">Surely you can&apos;t be serious! I am serious.And don&apos;t call me Shirley. Ted Striker & Rumack, Airplane! (1980)</a>',
        '<a href="https://www.imdb.com/title/tt0133093/">There is no page. Spoon Boy, The Matrix (1999)</a>',
        '<a href="https://www.imdb.com/title/tt0106977/">The page did a Peter Pan right off of this website, right here. Deputy Marshal Samuel Gerard, The Fugitive (1993)</a>',
        '<a href="https://www.imdb.com/title/tt0107048/">Well, what if there is no webpage? There wasn&apos;t one today. Phil Connors, Groundhog Day (1993)</a>',
        '<a href="https://www.imdb.com/title/tt0338013/">He&apos;s off the map! He&apos;s off the map! Stan, Eternal Sunshine of the Spotless Mind (2004)</a>',
        '<a href="https://www.imdb.com/title/tt0093779/">Page not found? INCONCEIVABLE. Vizzini, The Princess Bride (1987)</a>',
        '<a href="https://www.imdb.com/title/tt0110912/">It&apos;s the one that says &apos;Page not found&apos; Jules Winnfield, Pulp Fiction (1994)</a>'];
    return randomtxt[Math.floor((Math.random() * 13.99))];
}
// Aanroepbaar door id=spam te gebruiken
document.getElementById("random").innerHTML = randomtext();

