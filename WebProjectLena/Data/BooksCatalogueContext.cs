using Microsoft.EntityFrameworkCore;
using WebProjectLena.Models;

namespace WebProjectLena.Data
{
    public class BooksCatalogueContext : DbContext
    {
        public BooksCatalogueContext(DbContextOptions<BooksCatalogueContext> options) : base(options) { }
        public DbSet<BookModel>? Books { get; set; }
        public DbSet<GenreModel>? Genres { get; set; }
        public DbSet<CommentModel>? Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasData
            (
                new
                {
                    BookId = 1,
                    GenreId = 1,
                    ReleaseYear = 1970,
                    Title = "The Fellowship of the Ring",
                    Author = "GRR Tolkien",
                    ImageName = "lotr.PNG",
                    Description = "One Ring to rule them all, One Ring to find them, One Ring to bring them all and in the darkeness bind them\r\n\r\nIn ancient times the Rings of Power were crafted by the Elven-smiths, and Sauron, The Dark Lord, forged the One Ring, filling it with his own power so that he could rule all others. But the One Ring was taken from him, and though he sought it throughout Middle-earth, it remained lost to him. After many ages it fell into the hands of Bilbo Baggins, as told in The Hobbit.\r\n\r\nIn a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as his elderly cousin Bilbo entrusts the Ring to his care. Frodo must leave his home and make a perilous journey across Middle-earth to the Cracks of Doom, there to destroy the Ring and foil the Dark Lord in his evil purpose."
                },
                new
                {
                    BookId = 2,
                    GenreId = 1,
                    ReleaseYear = 1990,
                    Title = "Game Of Thrones",
                    Author = "George Martin",
                    ImageName = "got.png",
                    Description = "Long ago, in a time forgotten, a preternatural event threw the seasons out of balance. In a land where summers can last decades and winters a lifetime, trouble is brewing. The cold is returning, and in the frozen wastes to the north of Winterfell, sinister and supernatural forces are massing beyond the kingdom’s protective Wall. At the center of the conflict lie the Starks of Winterfell, a family as harsh and unyielding as the land they were born to. Sweeping from a land of brutal cold to a distant summertime kingdom of epicurean plenty, here is a tale of lords and ladies, soldiers and sorcerers, assassins and bastards, who come together in a time of grim omens."
                },
                new
                {
                    BookId = 3,
                    GenreId = 2,
                    ReleaseYear = 1813,
                    Title = "Pride And Prejudice",
                    Author = "Jane Austen",
                    ImageName = "pp.PNG",
                    Description = "Since its immediate success in 1813, Pride and Prejudice has remained one of the most popular novels in the English language. Jane Austen called this brilliant work \"her own darling child\" and its vivacious heroine, Elizabeth Bennet, \"as delightful a creature as ever appeared in print.\" The romantic clash between the opinionated Elizabeth and her proud beau, Mr. Darcy, is a splendid performance of civilized sparring. And Jane Austen's radiant wit sparkles as her characters dance a delicate quadrille of flirtation and intrigue, making this book the most superb comedy of manners of Regency England."
                },
                new
                {
                    BookId = 4,
                    GenreId = 1,
                    ReleaseYear = 2017,
                    Title = "The Bear and the Nightingale",
                    Author = "Katherine Arden",
                    ImageName = "tbatn.jpg",
                    Description = "Winter here lasts most of the year and the snowdrifts grow taller than houses. But Vasilisa doesn't mind--she spends the winter nights huddled around the embers of a fire with her beloved siblings, listening to her nurse's fairy tales. Above all, she loves the chilling story of Frost, the blue-eyed winter demon, who appears in the frigid night to claim unwary souls. Wise Russians fear him, her nurse says, and honor the spirits of house and yard and forest that protect their homes from evil.\nAfter Vasilisa's mother dies, her father goes to Moscow and brings home a new wife. Fiercely devout, city-bred, Vasilisa's new stepmother forbids her family from honoring the household spirits. The family acquiesces, but Vasilisa is frightened, sensing that more hinges upon their rituals than anyone knows.And indeed, crops begin to fail, evil creatures of the forest creep nearer, and misfortune stalks the village. All the while, Vasilisa's stepmother grows ever harsher in her determination to groom her rebellious stepdaughter for either marriage or confinement in a convent.\nAs danger circles, Vasilisa must defy even the people she loves and call on dangerous gifts she has long concealed--this, in order to protect her family from a threat that seems to have stepped from her nurse's most frightening tales."
                },
                new
                {
                    BookId = 5,
                    GenreId = 2,
                    ReleaseYear = 1967,
                    Title = "The Master and Margarita",
                    Author = "Mikhail Bulgakov",
                    ImageName = "mam.jpg",
                    Description = "Nothing in the whole of literature compares with The Master and Margarita. One spring afternoon, the Devil, trailing fire and chaos in his wake, weaves himself out of the shadows and into Moscow. Mikhail Bulgakov’s fantastical, funny, and devastating satire of Soviet life combines two distinct yet interwoven parts, one set in contemporary Moscow, the other in ancient Jerusalem, each brimming with historical, imaginary, frightful, and wonderful characters. Written during the darkest days of Stalin’s reign, and finally published in 1966 and 1967, The Master and Margarita became a literary phenomenon, signaling artistic and spiritual freedom for Russians everywhere."
                },
                new
                {
                    BookId = 6,
                    GenreId = 2,
                    ReleaseYear = 1936,
                    Title = "Gone With The Wind",
                    Author = "Margaret Mitchell",
                    ImageName = "gwtw.png",
                    Description = "Scarlett O'Hara, the beautiful, spoiled daughter of a well-to-do Georgia plantation owner, must use every means at her disposal to claw her way out of the poverty she finds herself in after Sherman's March to the Sea."
                },
                new
                {
                    BookId = 7,
                    GenreId = 3,
                    ReleaseYear = 1944,
                    Title = "The Complete Poems of Dorothy Parker",
                    Author = "Dorothy Parker",
                    ImageName = "tcwodp.jpg",
                    Description = "Dorothy Parker, master of the short story, dramatist, screenwriter, and sharp-tongued critic, was also an accomplished poet. At the center of the famed Round Table at New York's Algonquin Hotel, Parker distinguished herself among a circle of urbane literati with her excoriating quips and wonderfully realized epigrammatic poems. By the time her first collection of poems, Enough Rope, was published in 1926, she had been dubbed the wittiest woman in America.Confronting the hard facts of existence facing a woman of talent and boldness in the 1920s and '30s, Parker's poems depict a world haunted by unrequited love, alcohol, razor blades, and men of overbearing will. Her poetry earned much admiration from critics such as Odgen Nash, Somerset Maugham, and Edmund Wilson, who hailed it as \"flatly brutal as the wit of the age of Pope\". Complete Poems collects Parker's three volumes of poetry, Enough Rope, Sunset Gun, and Death and Taxes, as well as a hundred other previously uncollected works -- such as the hate songs, compact satiric descriptions of husbands and wives, actors and politicians, bores and ne'er-do-wells, and others who attracted her barbed pen."
                },
                new
                {
                    BookId = 8,
                    GenreId = 5,
                    ReleaseYear = 2017,
                    Title = "Mythos",
                    Author = "Stephen Fry",
                    ImageName = "tgmr.jpg",
                    Description = "The Greek myths are amongst the greatest stories ever told, passed down through millennia and inspiring writers and artists as varied as Shakespeare, Michelangelo, James Joyce and Walt Disney.\r\n\r\nThey are embedded deeply in the traditions, tales and cultural DNA of the West. You'll fall in love with Zeus, marvel at the birth of Athena, wince at Cronus and Gaia's revenge on Ouranos, weep with King Midas and hunt with the beautiful and ferocious Artemis.Spellbinding, informative and moving, Stephen Fry's Mythos perfectly captures these stories for the modern age - in all their rich and deeply human relevance"
                },
                new
                {
                    BookId = 9,
                    GenreId = 5,
                    ReleaseYear = 2019,
                    Title = "The Life Fantastic",
                    Author = "Noa Menhaim",
                    ImageName = "pc.jpg",
                    Description = "From monsters to witches and ancient libraries to lost islands, The Life Fantastic seeks to trace the origins of ideas, their surprising paths and unexpected ways in which they interact and manifest throughout history. By digging around the roots of literary genres, popular stories and ancient myths, Noa propels the reader back and forth through time, from high to popular culture, from art to politics and religion, on a journey to ever expanding horizons. The addition of side notes create a network of references between the chapters, allowing readers to follow links that interest them – to go from Amazons to Vikings, then to mermaids.\r\n\r\nDiscover the real life stories that inspired characters from the most famous children's tales, from Winnie the Pooh to Alice in Wonderland. Track the discovery of the lost island Atlantis through western history, from Plato to Aquaman. Explore the history of the female clitoris, from when it was thought to identify a witch to Aristotle asserting that only blondes can orgasm. The Life Fantastic is an invitation to explore the fascinating structure and some of the rich elements that make up the collective subconscious of western culture. "
                }
            );

            modelBuilder.Entity<GenreModel>().HasData
            (
                new { GenreId = 1, GenreName = "Fantasy" },
                new { GenreId = 2, GenreName = "Classic Fiction" },
                new { GenreId = 3, GenreName = "Poetry" },
                new { GenreId = 4, GenreName = "Mystery" },
                new { GenreId = 5, GenreName = "Non Fiction" }

            );

            modelBuilder.Entity<CommentModel>().HasData
            (
                new { CommentId = 1,  BookId = 2, Comment = "Wow! Best book I ever read!" },
                new { CommentId = 2,  BookId = 2, Comment = "I wish there was less violence :(" },
                new { CommentId = 3,  BookId = 2, Comment = "Oh sweet summer child... you don't know what's to come." },
                new { CommentId = 4,  BookId = 1, Comment = "I swear if I hear another song about a tree..." },
                new { CommentId = 5,  BookId = 1, Comment = "Tolkien is a master of creating worlds, languages and other people, elves are awseome" },
                new { CommentId = 6,  BookId = 6, Comment = "I wish Rett Butler was real, such a good character!" },
                new { CommentId = 7,  BookId = 4, Comment = "This book is magical. This book is whimsical. This book is one of the best things I’ve read in my entire life. I loved this with every bone, every red blood cell, every molecule in my body. This book was nothing short of perfection, and I’m sorry to gush, but I never expected this story to captivate me the way it did." },
                new { CommentId = 8,  BookId = 4, Comment = "Words cannot describe how much I cherish this book. The characters were described so well and the story was absolutely fantastic and so magical." },
                new { CommentId = 9,  BookId = 4, Comment = "This was such an enjoyable book to read. I loved it and wished the story would have continued on for a couple more chapters. But, I guess that what makes this story so good." },
                new { CommentId = 10, BookId = 4, Comment = "I've been wanting to read this for so long and have finally gotten to it (it helps that all the books on the trilogy after out so I can binge). So excited to delve into this crisp world of magic" },
                new { CommentId = 11, BookId = 4, Comment = "I liked certain things about the book but overall it wasn't for me. Don't know if it was the book or my mood but I'm glad there are so many people loving it." },
                new { CommentId = 12, BookId = 4, Comment = "Magical is the word that best describes this unusual tale, in every sense. I have to say that I've not read anything quite like this one, but believe me, that IS meant as a compliment." },
                new { CommentId = 13, BookId = 1, Comment = "Best read ever." },
                new { CommentId = 14, BookId = 1, Comment = "I have been slowly rereading The Lord of the Rings by J. R. R. Tolkien over the last few months and I’ve loved every moment of it. I read these fantasy books years ago, and I used to watch the films over and over again, so this is a series that has shaped my life." },
                new { CommentId = 15, BookId = 1, Comment = "One of the few books that can truly lay claim to the word classic, because it will and always shall be a true classic. I love these books so much. Literally grew up reading them and they are forever a piece of my literary soul." },
                new { CommentId = 16, BookId = 1, Comment = "This is the story of Frodo who goes on an impossible quest to destroy a very powerful and magical ring. Along the way, Frodo travels with various characters, and they find themselves constantly in peril." },
                new { CommentId = 17, BookId = 1, Comment = "The true source of the fantasy fiction genre. Tolkien has spawned so many fantasy writers since The Lord Of The Rings went into print. I love all the earlier ones too like Verne and Carrol and CS Lewis but The Hobbit and The Lord Of The Rings its like an institution." },
                new { CommentId = 18, BookId = 1, Comment = "It remains the best of its genre, no matter how many fantasy worlds have emerged since!" },
                new { CommentId = 19, BookId = 1, Comment = "I know I read this series at the tender age of eight, when I was very impressionable and very eager to get obsessed with anything. But I think these are better than we give them credit for." },
                new { CommentId = 20, BookId = 1, Comment = "Very popular and influential fantasy novel. Although alternatively a non-multi-media version of the same concerns and inspirations as Wagner's Ring cycle." },
                new { CommentId = 21, BookId = 6, Comment = "Let me be candid: I'm not a huge fan of casual Southern racism no matter how charmingly couched in close-knit family ties, genteel manners, or explosively self-destructive values that leave them all ripe for exploitation. Nor am I all that fond of the damn Yankees, either, if I must be honest." },
                new { CommentId = 22, BookId = 6, Comment = "This is such a good comfort read. The film with Clark Gable and Vivian Leigh is what I envisage as I am reading." },
                new { CommentId = 23, BookId = 6, Comment = "Wow! Even better, in fact much better, than the movie. Any piece of literature that can move some many different emotions in the reader is truly a classic. GWTW is a classic. I can’t wait to read it again." },
                new { CommentId = 24, BookId = 6, Comment = "I disliked every single character and their miserable lives. I want my time back." },
                new { CommentId = 25, BookId = 5, Comment = "One of my reading themes for 2016 is reading at least ten classic books. It seems only fitting that on the Fourth of July I completed Margaret Mitchell's Gone With the Wind, an epic masterpiece that many view as the definitive great American novel." },
                new { CommentId = 26, BookId = 5, Comment = "The Master and Margarita by Soviet era writer Mikhail Bulgakov seems to inspire strong emotions though most critics and commentators have been impressed with the fantastic satire. Le Monde listed the novel number 94 on its 100 books of the century. I found it absurd, outrageous, inconsistent, but for the most part entertaining." },
                new { CommentId = 27, BookId = 5, Comment = "There are very few things I can say about this novel except it's Brilliant, Brilliant, Brillant. That, and I am afraid I'm a total fanboy of all Russian novelists and this one in particular." },
                new { CommentId = 28, BookId = 5, Comment = "Extremely funny and entertaining in parts, but by the end it all felt a little hollow. Maybe I missed the point." },
                new { CommentId = 29, BookId = 3, Comment = "If you want to read one of the best books ever written, please don't think twice. Just grab a copy of this book and get yourself imbibed into this evocative story that right away establishes an emotional connection with us." },
                new { CommentId = 30, BookId = 3, Comment = "Eh, just okay. Basically a character study of 19th century England, society, courtship, etc. Nothing all that mind blowing or enthralling happens. In fact, not much really happens at all." },
                new { CommentId = 31, BookId = 3, Comment = "Pulls me in every time, regardless of how wordy it is. I need to read more Austen now, and obvs watch every adaptation of every of her novels." },
                new { CommentId = 32, BookId = 3, Comment = "With great pride, I admit I'm a big fan of Pride and Prejudice. I've consistently ignored the fact that it is a Romance novel, that it is full of flighty girls doing silly things and jumping to massive conclusions without even a speck of proof, and I've totally discounted the fact that just about everyone on the planet has read it." },
                new { CommentId = 33, BookId = 3, Comment = "A beautifully written classic, the only way it could be better is to add zombies!" },
                new { CommentId = 34, BookId = 1, Comment = "Raise your hand if you remember the awesome book fairs or Scholastic book order forms from back when you were a kid? Well, in middle school I picked up this sweet read in a box set with the rest of the trilogy and The Hobbit. Unfortunately, while I have always been enthusiastic about reading, I did not find the motivation to complete it for almost 15 years." },
                new { CommentId = 35, BookId = 1, Comment = "I’ll always love the trilogy. This set with covers by John Jude Palencar is beautiful. Definitely a keeper! Review to follow…" },
                new { CommentId = 36, BookId = 1, Comment = "The hobbits are back, and this time they're walking even farther than ever before." },
                new { CommentId = 37, BookId = 1, Comment = "Like all books of this magnitude, Tolkien's Fellowship of the Ring is defintely one every reviewer probably ponders on how to do justice to after reading. It's no easy feat i must tell you, but here i am trying to do justice to this classic" },
                new { CommentId = 38, BookId = 1, Comment = "This was absolutely fantastic!" },
                new { CommentId = 39, BookId = 7, Comment = "Just as scathing, bitter and witty as you would expect; in places it is truly upsetting to see a woman so plagued by her own mortality and futility, in other places it is comforting, with its sing song rhyme and humour" },
                new { CommentId = 40, BookId = 7, Comment = "Love me a sharp line and an good rhyme" },
                new { CommentId = 41, BookId = 7, Comment = "I adore Dorothy Parker, my misanthropic soul mate, who is super witty and never dull. This book is always close by, as I read her poems over and over again." },
                new { CommentId = 42, BookId = 8, Comment = "Pleasantly surprised as Stephen Fry spins excellent stories around Greek Gods. His research and storytellings are excellent." },
                new { CommentId = 43, BookId = 4, Comment = "What started up as an adventure oriented for children turned into an epic fantasy..." },
                new { CommentId = 44, BookId = 4, Comment = "Would read again!" },
                new { CommentId = 45, BookId = 4, Comment = "This book is everything I never knew I needed in my life!" },
                new { CommentId = 46, BookId = 4, Comment = "Over all, it was such a rarely amazing book! If you love strong, defiant and brave heroines, magic, fairy-tales, endless forests and dark snowy nights, you should definitely give this one a chance!" },
                new { CommentId = 47, BookId = 4, Comment = "this cover is so beautiful, my eyes are made up of sparkles and glitter at this point." }
            );
        }
    }
}
