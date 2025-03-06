using Core;
using eFilm.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // Reset identity (ActorId) after clearing ActorsTable
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('ActorsTable', RESEED, 0);"); //This resets ID to 0 when placing new data.

                //Cinema
                if (!context.CinemasTable.Any()) // Remove if statement to seed new data
                {
                    context.CinemasTable.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Odeon Cinemas",
                            Logo = "https://tse1.mm.bing.net/th?id=OIP.UllD1PU9-jaQ8yhs0b1SDAHaDU&pid=Api",
                            Description = "Odeon is one of the UK's largest and most established cinema chains, with over 100 locations nationwide. Founded in 1928, it has a long-standing reputation for showcasing a wide range of films, from the latest blockbusters to independent releases. Many Odeon venues feature premium offerings such as IMAX screens and luxury seating options."
                        },
                        new Cinema()
                        {
                            Name = "Cineworld Cinemas",
                            Logo = "https://tse4.mm.bing.net/th?id=OIP.tQJi3yiJH0KnCea0XrSujwHaFj&pid=Api",
                            Description = "Cineworld operates numerous cinemas across the UK and is known for its diverse film selections and modern facilities. The chain offers various premium formats, including IMAX, 4DX, and ScreenX, enhancing the movie-going experience with advanced technology and comfort."
                        },
                        new Cinema()
                        {
                            Name = "Vue Cinemas",
                            Logo = "https://tse2.mm.bing.net/th?id=OIP.KpxhtD8qak03F_pEHkcVOgHaHW&pid=Api",
                            Description = "Vue is a prominent cinema chain in the UK, offering state-of-the-art auditoriums with high-quality sound and vision technology. With numerous locations, Vue provides a wide selection of films, from mainstream blockbusters to special event screenings, ensuring a comprehensive cinematic experience for its audience."
                        },
                        new Cinema()
                        {
                            Name = "Everyman Cinemas",
                            Logo = "https://tse1.mm.bing.net/th?id=OIP.H6rUxMBxJPVzvFkx2_a5SQHaDS&pid=Api",
                            Description = "Everyman offers a boutique cinema experience, focusing on comfort and luxury. With a selection of locations across the UK, Everyman provides a unique movie-going experience with plush seating and in-screen dining options."
                        },
                        new Cinema()
                        {
                            Name = "The Light Cinemas",
                            Logo = "https://th.bing.com/th/id/OIP.O_KR7mJAoD-IyTT_yRbDnQHaCO?rs=1&pid=ImgDetMain",
                            Description = "The Light Cinemas is an independent chain that focuses on providing a premium yet affordable cinema experience. With multiple locations, they offer a mix of mainstream and independent films, as well as special events and live broadcasts. The venues often feature comfortable seating and a welcoming atmosphere, aiming to create a community hub for film enthusiasts."
                        },

                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.ActorsTable.Any())
                {
                    context.ActorsTable.AddRange(new List<Actor>()
                    {
                      new Actor()
                      {
                            FullName = "Brad Pitt",
                            Bio = "Brad Pitt is an American actor and film producer known for his versatile performances in films like Fight Club, Seven, and Once Upon a Time in Hollywood. He has won multiple awards, including an Academy Award for Best Supporting Actor.",
                            ProfilePictureURL = "https://www.masala.com/sites/default/files/styles/large/public/2022/11/22/brad-pitt-1.jpg"
                      },
                        new Actor()
                        {
                            FullName = "Christoph Waltz",
                            Bio = "Christoph Waltz is an Austrian-German actor known for his compelling villainous roles. He gained international fame for his performances in Inglourious Basterds and Django Unchained, both earning him Academy Awards.",
                            ProfilePictureURL = "https://prabook.com/web/large/chrwaltz.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Denzel Washington",
                            Bio = "Denzel Washington is an American actor, director, and producer, known for his powerful performances in Training Day, Malcolm X, and American Gangster. He is a two-time Academy Award winner.",
                            ProfilePictureURL = "https://927theblock.com/wp-content/uploads/2021/11/denzel-washington-then-now.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Russell Crowe",
                            Bio = "Russell Crowe is a New Zealand-born actor known for his intense and transformative performances in films like Gladiator, A Beautiful Mind, and Les Misérables. He won an Academy Award for Gladiator.",
                            ProfilePictureURL = "https://www.accessonline.com/wp-content/uploads/2017/10/russell-crowe.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Elijah Wood",
                            Bio = "Elijah Wood is an American actor and producer best known for playing Frodo Baggins in The Lord of the Rings trilogy. His career spans multiple genres, including voice acting in animated films and TV series.",
                            ProfilePictureURL = "https://i.pinimg.com/originals/2f/0d/0b/2f0d0b8c8a8a8a8a8a8a8a8a8a8a8a8a.jpg"
                        }

                    });
                    context.SaveChanges();

                    //Producers
                    if (!context.ProducersTable.Any())
                    {
                        context.ProducersTable.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                        context.SaveChanges();
                    }
                    //Movies
                    if (!context.MoviesTable.Any())
                    {
                        context.MoviesTable.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                        context.SaveChanges();
                    }
                    //Actors & Movies
                    if (!context.Actors_Movies.Any())
                    {
                        context.Actors_Movies.AddRange(new List<Actor_Movie>()
                        {
                            new Actor_Movie()
                            {
                                ActorId = 1,
                                MovieId = 1
                            },
                            new Actor_Movie()
                            {
                                ActorId = 3,
                                MovieId = 1
                            },

                             new Actor_Movie()
                            {
                                ActorId = 1,
                                MovieId = 2
                            },
                             new Actor_Movie()
                            {
                                ActorId = 4,
                                MovieId = 2
                            },

                            new Actor_Movie()
                            {
                                ActorId = 1,
                                MovieId = 3
                            },
                            new Actor_Movie()
                            {
                                ActorId = 2,
                                MovieId = 3
                            },
                            new Actor_Movie()
                            {
                                ActorId = 5,
                                MovieId = 3
                            },


                            new Actor_Movie()
                            {
                                ActorId = 2,
                                MovieId = 4
                            },
                            new Actor_Movie()
                            {
                                ActorId = 3,
                                MovieId = 4
                            },
                            new Actor_Movie()
                            {
                                ActorId = 4,
                                MovieId = 4
                            },


                            new Actor_Movie()
                            {
                                ActorId = 2,
                                MovieId = 5
                            },
                            new Actor_Movie()
                            {
                                ActorId = 3,
                                MovieId = 5
                            },
                            new Actor_Movie()
                            {
                                ActorId = 4,
                                MovieId = 5
                            },
                            new Actor_Movie()
                            {
                                ActorId = 5,
                                MovieId = 5
                            },


                            new Actor_Movie()
                            {
                                ActorId = 3,
                                MovieId = 6
                            },
                            new Actor_Movie()
                            {
                                ActorId = 4,
                                MovieId = 6
                            },
                            new Actor_Movie()
                            {
                                ActorId = 5,
                                MovieId = 6
                            },
                        });
                        context.SaveChanges();
                    }
                }

            }

        }


    }
}
