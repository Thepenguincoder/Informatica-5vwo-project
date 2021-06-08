// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Code voor de random tekst in de 404 pagina.
function randomtext() {
    var randomtxt = [
        'Always remember, Frodo, the page is trying to get back to its master. It wants to be found.<br><a href="https://www.imdb.com/title/tt0120737/"><i>Gandalf, The Lord of the Rings: The Fellowship of the Ring (2001)</i></a>',
        'Webpages? Where we&apos;re going, we don&apos;t need webpages.<br><a href="https://www.imdb.com/title/tt0088763/"><i> Dr. Emmett Brown, Back to the Future (1985)</i></a>',
        'Where&apos;s the page, Lebowski? Where&apos;s the page?<br><a href="https://www.imdb.com/title/tt0118715/"><i> Blond Thug, The Big Lebowski (1998)</i></a>',
        'What we&apos;ve got here is...failure to communicate.<br><a href="https://www.imdb.com/title/tt0061512/"><i> Captain, Cool Hand Luke (1967)</i></a>',
        'Lord! It&apos;s a miracle! Webpage up and vanished like a fart in the wind!<br><a href="https://www.imdb.com/title/tt0111161/"><i> Warden Norton, The Shawshank Redemption (1994)</i></a>',
        'What&apos;s on the page?<br><a href="https://www.imdb.com/title/tt0114369/"><i> Detective David Mills, Se7en (1995)</i></a>',
        'This is not the webpage you&apos;re looking for.<br><a href="https://www.imdb.com/title/tt0076759/"><i> Obi-Wan Kenobi, Star Wars: Episode IV - A New Hope (1977)</i></a>',
        'Surely you can&apos;t be serious! I am serious. And don&apos;t call me Shirley.<br><a href="https://www.imdb.com/title/tt0080339/"><i> Ted Striker & Rumack, Airplane! (1980)</i></a>',
        'There is no page.<br><a href="https://www.imdb.com/title/tt0133093/"><i> Spoon Boy, The Matrix (1999)</i></a>',
        'The page did a Peter Pan right off of this website, right here.<br><a href="https://www.imdb.com/title/tt0106977/"><i> Deputy Marshal Samuel Gerard, The Fugitive (1993)</i></a>',
        'Well, what if there is no webpage? There wasn&apos;t one today.<br><a href="https://www.imdb.com/title/tt0107048/"><i> Phil Connors, Groundhog Day (1993)</i></a>',
        'He&apos;s off the map! He&apos;s off the map!<br><a href="https://www.imdb.com/title/tt0338013/"><i> Stan, Eternal Sunshine of the Spotless Mind (2004)</i></a>',
        'Page not found? INCONCEIVABLE.<br><a href="https://www.imdb.com/title/tt0093779/"><i> Vizzini, The Princess Bride (1987)</i></a>',
        'It&apos;s the one that says &apos;Page not found&apos;<br><a href="https://www.imdb.com/title/tt0110912/"><i> Jules Winnfield, Pulp Fiction (1994)</i></a>',
        'Yeah... I&apos;m gonna need you to go ahead and find another page.<br><a href="https://www.imdb.com/title/tt0151804/"><i> Bill Lumbergh, Office Space (1999)</i></a>',
        'Dude, where&apos;s my webpage ?<br><a href="https://www.imdb.com/title/tt0242423/"><i> Jesse Montgomery III, Dude, Where&apos;s My Car ? (2000) </i></a>',
        'Someday we&apos;ll find it...the website connection...<br><a href="https://www.imdb.com/title/tt0079588/"><i> Kermit the Frog, The Muppet Movie (1979)</i></a>'];
    return randomtxt[Math.floor((Math.random() * 16.99))];
}
// Aanroepbaar door id=spam te gebruiken
document.getElementById("random").innerHTML = randomtext();

