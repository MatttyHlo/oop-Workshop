# oop-Workshop
Repository used for OOP Workshop

## UML Diagram

```mermaid
classDiagram
    %% Interfaces
    class IDownloadable {
        <<interface>>
        +Download(url: string) void
    }
    
    class IRatable {
        <<interface>>
        +Rate(rating: int) void
    }
    
    class IPlayable {
        <<interface>>
        +Play() void
    }
    
    %% Base Classes
    class User {
        <<abstract>>
        +Name: string
        +Age: int
        +SocialSecurityNumber: int
        +User(name: string, age: int, ssn: int)
    }
    
    class Media {
        +title: string
    }
    
    %% User Hierarchy
    class Admin {
        +Admin(name: string, age: int, ssn: int)
    }
    
    class Employee {
        +Employee(name: string, age: int, ssn: int)
    }
    
    class Borrower {
        +Borrower(name: string, age: int, ssn: int)
    }
    
    %% Media Types
    class EBook {
        +Author: string
        +Language: string
        +NumberOfPages: int
        +YearOfPublication: int
        +ISBN: string
        +EBook(title, author, language, numberOfPages, yearOfPublication, isbn)
        +Download(url: string) void
        +View() void
        +Read() void
        +Rate(rating: int) void 
    }
    
    class Movie {
        +Director: string
        +Genres: string[]
        +ReleaseYear: int
        +Language: string
        +Duration: int
        +Movie(title, director, genres, releaseYear, language, duration)
        +Download(url: string) void
        +Rate(rating: int) void
        +Watch() void
    }
    
    class Song {
        +Composer: string
        +Singer: string
        +Genre: string
        +FileType: string
        +Duration: int
        +Language: string
        +Song(title, composer, singer, genre, fileType, duration, language)
        +Download(url: string) void
        +Play() void
        +Rate(rating: int) void
    }
    
    class VideoGame {
        +Genre: string
        +Publisher: string
        +ReleaseYear: int
        +SupportedPlatforms: string[]
        +VideoGame(title, genre, publisher, releaseYear, supportedPlatforms)
        +Download(url: string) void
        +Play() void
        +Complete() void
        +Rate(rating: int) void
    }
    
    class App {
        +Version: string
        +Publisher: string
        +SupportedPlatforms: string[]
        +FileSize: double
        +App(title, version, publisher, supportedPlatforms, fileSize)
        +Download(url: string) void
        +Execute() void
        +Rate(rating: int) void
    }
    
    class Podcast {
        +ReleaseYear: int
        +Hosts: string[]
        +Guests: string[]
        +EpisodeNumber: int
        +Language: string
        +Podcast(title, releaseYear, hosts, guests, episodeNumber, language)
        +Download(url: string) void
        +Listen() void
        +Complete() void
        +Rate(rating: int) void
    }
    
    class Image {
        +Resolution: string
        +FileFormat: string
        +FileSize: double
        +DateTaken: DateTime
        +Image(title, resolution, fileFormat, fileSize, dateTaken)
        +Download(url: string) void
        +Display() void
        +Rate(rating: int) void
    }
    
    %% Inheritance Relationships
    User <|-- Admin
    User <|-- Employee
    User <|-- Borrower
    
    Media <|-- EBook
    Media <|-- Movie
    Media <|-- Song
    Media <|-- VideoGame
    Media <|-- App
    Media <|-- Podcast
    Media <|-- Image
    
    %% Interface Implementations
    IDownloadable <|.. EBook
    IRatable <|.. EBook
    
    IDownloadable <|.. Movie
    IRatable <|.. Movie
    
    IDownloadable <|.. Song
    IPlayable <|.. Song
    IRatable <|.. Song
    
    IDownloadable <|.. VideoGame
    IPlayable <|.. VideoGame
    IRatable <|.. VideoGame
    
    IDownloadable <|.. App
    IRatable <|.. App
    
    IDownloadable <|.. Podcast
    IRatable <|.. Podcast
    
    IDownloadable <|.. Image
    IRatable <|.. Image
```
# Verb-noun analysis

## Media:

E-books: view, download, read (title, author, language, pages, year, ISBN)

Movies: watch, download (title, director, genres, release year, language, duration)

Songs: play, download (title, composer, singer, genre, file type, duration, language)

Video-games: download, play, complete (title, genre, publisher, release year, platforms)

Apps: download, execute (title, version, publisher, platforms, file size)

Podcasts: download, listen, complete (title, release year, host, guest, episode number, language)

Images: download, display (title, resolution, file format, file size, date taken)

All media: borrow, rate

## Roles:

Borrower: list, select, preview, rate, borrow, perform (actions specific to media)

Employee: add, remove (media items)

Admin: manage (users and collection), view, create, delete, update (user info)

# Requirements CRC

## Functional Requirements

| ID   | Name                  | Description                                            |
|------|-----------------------|--------------------------------------------------------|
| F01  | View e-books          | It must be possible to view e-books                    |
| F02  | Download e-books      | It must be possible to download e-books                |
| F03  | Read e-books          | It must be possible to read e-books                    |
| F04  | Watch movies          | It must be possible to watch movies                    |
| F05  | Download movies       | It must be possible to download movies                 |
| F06  | Play songs            | It must be possible to play songs                      |
| F07  | Download songs        | It must be possible to download songs                  |
| F08  | Play video-games      | It must be possible to play video-games                |
| F09  | Download video-games  | It must be possible to download video-games            |
| F10  | Complete video-games  | It must be possible to complete video-games            |
| F11  | Download apps         | It must be possible to download apps                   |
| F12  | Execute apps          | It must be possible to execute apps                    |
| F13  | Download podcasts     | It must be possible to download podcasts               |
| F14  | Listen podcasts       | It must be possible to listen to podcasts              |
| F15  | Complete podcasts     | It must be possible to complete podcasts               |
| F16  | Download images       | It must be possible to download images                 |
| F17  | Display images        | It must be possible to display images                  |
| F18  | Borrow e-books        | It must be possible to borrow e-books                  |
| F19  | Borrow movies         | It must be possible to borrow movies                   |
| F20  | Borrow songs          | It must be possible to borrow songs                    |
| F21  | Borrow video-games    | It must be possible to borrow video-games              |
| F22  | Borrow apps           | It must be possible to borrow apps                     |
| F23  | Borrow podcasts       | It must be possible to borrow podcasts                 |
| F24  | Borrow images         | It must be possible to borrow images                   |
| F25  | Rate media items      | It must be possible to rate media items (if borrowed)  |
| F26  | Choose role           | It must be possible to choose a role (admin, etc.)     |
| F27  | Borrower interacts    | Borrower can list items by type                        |
| F28  | Borrower selects      | Borrower can select and preview details                |
| F29  | Borrower rates items  | Borrower can rate items                                |
| F30  | Borrower performs     | Actions specific to media type                         |
| F31  | Employee manages      | Employee can add or remove media items                 |
| F32  | Admin manages coll.   | Admin can add/remove media items                       |
| F33  | Admin manages Borrow. | Admin can CRUD borrower info                           |
| F34  | Admin manages Empl.   | Admin can CRUD employee info                           |

## Non-Functional Requirements

| ID   | Name          | Description                                                  |
|------|---------------|--------------------------------------------------------------|
| NF01 | Availability  | All supported actions should be available to all user types  |
| NF02 | Structure     | Must be structured in a clear way                            |
| NF03 | Validate      | The console interface must validate all inputs               |
| NF04 | Instructions  | The console interface must provide clear instructions        |
| NF05 | Handle errors | Errors or invalid actions must not be passed through         |
| NF06 | Extensibility | Must allow eventual addition of new media/user types         |

## CRC Cards

### Media

| Responsibilities                                  | Collaborators                               |
|---------------------------------------------------|---------------------------------------------|
| Can be inherited by all media types               | App, EBook, Image, Movie, Podcast, Song, VideoGames |

### User

| Responsibilities                                  | Collaborators                   |
|---------------------------------------------------|---------------------------------|
| Can be inherited by all user types                | Admin, Borrower, Employee       |

### App

| Responsibilities                                                                                     | Collaborators |
|------------------------------------------------------------------------------------------------------|--------------|
| Store data (supported platforms, app title (from Media), Version, Publisher, FileSize)<br>Allow download, rate, and execute actions | Media        |

### EBook

| Responsibilities                                                                                            | Collaborators |
|-------------------------------------------------------------------------------------------------------------|--------------|
| Store data (title, author, language, pages, year, ISBN)<br>Allow download, view, read, and rate actions      | Media        |

### Image

| Responsibilities                                                      | Collaborators |
|-----------------------------------------------------------------------|--------------|
| Store data (title, resolution, format, size, date)<br>Allow download, display, and rate actions | Media        |

### Movie

| Responsibilities                                                              | Collaborators |
|-------------------------------------------------------------------------------|--------------|
| Store data (title, director, genres, year, language, duration)<br>Allow download, watch, and rate actions | Media        |

### Podcast

| Responsibilities                                                                      | Collaborators |
|---------------------------------------------------------------------------------------|--------------|
| Store data (title, year, hosts, guests, episode number, language)<br>Allow download, rate, listen, complete | Media        |

### Song

| Responsibilities                                                                          | Collaborators |
|-------------------------------------------------------------------------------------------|--------------|
| Store data (title, composer, singer, genre, file type, duration, language)<br>Allow download, play, and rate actions | Media        |

### VideoGame

| Responsibilities                                                                      | Collaborators |
|---------------------------------------------------------------------------------------|--------------|
| Store data (title, genre, publisher, year, platforms)<br>Allow download, play, complete, and rate actions | Media        |

### Admin

| Responsibilities                                                                                                           | Collaborators                      |
|----------------------------------------------------------------------------------------------------------------------------|------------------------------------|
| Inherit user attributes and behavior<br>All Employee privileges (add/remove media, manage collection)<br>Manage users (CRUD Borrowers, Employees) | User, Employee, Borrower, Media    |

### Employee

| Responsibilities                                                                                            | Collaborators |
|-------------------------------------------------------------------------------------------------------------|--------------|
| Inherit user attributes and behavior<br>Interact with media collection<br>List, preview, borrow, rate, perform media-specific actions | Media        |

### Borrower

| Responsibilities                                                                                            | Collaborators |
|-------------------------------------------------------------------------------------------------------------|--------------|
| Inherit user attributes and behavior<br>Interact with media collection<br>List, preview, borrow, rate (if borrowed), perform media-specific actions | Media        |



