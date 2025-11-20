// See https://aka.ms/new-console-template for more information

using FileManagement;
using FileManagement.Domain.Implemetations;

Console.WriteLine("Hello, World!");


// IMovieRepository repository = null;
//
//
// var allMovies = repository.GetAll();
// Console.WriteLine(allMovies.Count);



var movieSingleton = new Movie("Test", 2000);
var movieSingleton2 = new Movie("Test 2", 2000);
MovieSingleton.CreateNewInstance(movieSingleton);
MovieSingleton.CreateNewInstance(movieSingleton2);

var fromSingleton = MovieSingleton.Instance;
Console.WriteLine($"Movie singleton is the same as fromSingleton: {movieSingleton.Equals(fromSingleton)}");
Console.WriteLine($"Movie singleton2 is the same as fromSingleton: {movieSingleton2.Equals(fromSingleton)}");

var factoryMovie = MovieStaticFactory.GetFastAndFurious1();
Console.WriteLine($"FacotryMovie: {factoryMovie}");
var factoryMoviePart = MovieStaticFactory.GetFastAndFurious(2);
Console.WriteLine($"factoryMoviePart: {factoryMoviePart}");



var movieFactory = new MovieFactory("FromFactory");
var movieFactoryInstance = movieFactory.GetFastAndFurious1();
Console.WriteLine($"movieFactoryInstance: {movieFactoryInstance}");
Console.WriteLine($"movieFactoryInstance name: {movieFactoryInstance.Name}");


var builder = new MovieBuilder();

builder
    .AddName("Horton")
    .AddYear(2007)
    .AddName("new Horton");
var hortonMovie = builder.Build();
Console.WriteLine($"hortonMovie: {hortonMovie}");
