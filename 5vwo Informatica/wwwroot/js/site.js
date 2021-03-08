// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




// Code voor de random tekst in de 404 pagina.
function randomtext() {
    var randomtxt = [
        'Always remember, Frodo, the page is trying to get back to its master. It wants to be found. Gandalf, <a href="https://www.imdb.com/title/tt0120737/"> The Lord of the Rings: The Fellowship of the Ring (2001)</a>',
        'Webpages? Where we&apos;re going, we don&apos;t need webpages. Dr. Emmett Brown, <a href="https://www.imdb.com/title/tt0088763/"> Back to the Future (1985)</a>',
        'Where&apos;s the page, Lebowski ? Where&apos;s the page? Blond Thug, <a href="https://www.imdb.com/title/tt0118715/"> The Big Lebowski (1998)</a>',
        'What we&apos;ve got here is...failure to communicate. Captain, <a href="https://www.imdb.com/title/tt0061512/"> Cool Hand Luke (1967)</a>',
        'Lord! It&apos;s a miracle! Webpage up and vanished like a fart in the wind! Warden Norton, <a href="https://www.imdb.com/title/tt0111161/"> The Shawshank Redemption (1994)</a>',
        'What&apos;s on the page ? Detective David Mills, <a href="https://www.imdb.com/title/tt0114369/"> Se7en (1995)</a>',
        'This is not the webpage you&apos;re looking for. Obi-Wan Kenobi, <a href="https://www.imdb.com/title/tt0076759/"> Star Wars: Episode IV - A New Hope (1977)</a>',
        'Surely you can&apos;t be serious! I am serious.And don&apos;t call me Shirley. Ted Striker & Rumack, <a href="https://www.imdb.com/title/tt0080339/"> Airplane! (1980)</a>',
        'There is no page. Spoon Boy, <a href="https://www.imdb.com/title/tt0133093/"> The Matrix (1999)</a>',
        'The page did a Peter Pan right off of this website, right here. Deputy Marshal Samuel Gerard, <a href="https://www.imdb.com/title/tt0106977/"> The Fugitive (1993)</a>',
        'Well, what if there is no webpage? There wasn&apos;t one today. Phil Connors, <a href="https://www.imdb.com/title/tt0107048/"> Groundhog Day (1993)</a>',
        'He&apos;s off the map! He&apos;s off the map! Stan, <a href="https://www.imdb.com/title/tt0338013/"> Eternal Sunshine of the Spotless Mind (2004)</a>',
        'Page not found? INCONCEIVABLE. Vizzini, <a href="https://www.imdb.com/title/tt0093779/"> The Princess Bride (1987)</a>',
        'It&apos;s the one that says &apos;Page not found&apos; Jules Winnfield, <a href="https://www.imdb.com/title/tt0110912/"> Pulp Fiction (1994)</a>'];
    return randomtxt[Math.floor((Math.random() * 13.99))];
}
// Aanroepbaar door id=spam te gebruiken
document.getElementById("spam").innerHTML = randomtext();