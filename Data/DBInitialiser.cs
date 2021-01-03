using IS4439_CA2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Data
{
    public class DBInitialiser
    {
        public static void InitialiseAsync(ApplicationDbContext context)
        {
     
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                List<ApplicationUser> applicationUsers = new List<ApplicationUser>()
                {
                    new ApplicationUser(){Email="kieranomahony@gmail.com",NormalizedEmail="KIERANOMAHONY@GMAIL.COM", FullName="Kieran O Mahony", IsAdmin=true, Occupation="Student", UserName="kieranomahony@gmail.com", NormalizedUserName="KIERANOMAHONY@GMAIL.COM"},
                    new ApplicationUser(){Email="andrea@gmail.com", NormalizedEmail="ANDREA@GMAIL.COM", FullName="Andrea Visentin", IsAdmin=false, Occupation="Lecture", UserName="andrea@gmail.com", NormalizedUserName="ANDREA@GMAIL.COM"},
                };
                PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();

                foreach (ApplicationUser application in applicationUsers)
                {
                    application.PasswordHash = ph.HashPassword(application, "myPassword12*");
                    context.Users.Add(application);
                }

                context.SaveChanges();
            }
            if (!context.Projects.Any())
            {
                string imagePathEmpire = "/Projects/behind_the_empire/";
                string imagePathAnxieteen = "/Projects/anxieteen/";
                string imagePathWhopper = "/Projects/rise_of_the_whopper/";
                string imagePathMyVote = "/Projects/my_vote/";
                string imagePathHomes = "/Projects/pro_energy_homes/";
                string imagePathExpand = "/Projects/expand/";
                
                List<ProjectImages> anxieteenMedia = new List<ProjectImages>()
                {
                           new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxieteen.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Poster_1.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_2.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_3.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_4.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_5.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_6.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_7.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_8.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Anxiety_Spread_9.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Axieteen_Billboard_Mockup.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathAnxieteen}Mockup_Magazine.jpg"},
                };

                List<ProjectImages> myVoteMedia = new List<ProjectImages> {
                                            new ProjectImages{imageRoute=$"~{imagePathMyVote}MyVote_Hero-01.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathMyVote}MyVote_Page2.jpg"},
                };

                List<ProjectImages> whopperMedia = new List<ProjectImages> {
                                            new ProjectImages{imageRoute=$"~{imagePathWhopper}Rise_Of_The_Whopper-02.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathWhopper}bkphones.jpg"},
                };

                List<ProjectImages> empireMedia = new List<ProjectImages>
                {
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}Front_cover.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}Star_Wars_Overview.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}1_2.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}2_3.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}4_5.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}6_7.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}8_9.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}10_11.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}12_13.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}14_15.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}16_17.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathEmpire}18_19.jpg"},
                };
                List<ProjectImages> proHomes = new List<ProjectImages>()
                {
                                            new ProjectImages{imageRoute=$"~{imagePathHomes}Pro_Energy_Homes_Logo.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathHomes}Pro_Energy_Brochure.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathHomes}Pro_Energy_Pull_Ups.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathHomes}Pro_Energy_Web_Phone.jpg"},
                };
                List<ProjectImages> expandMedia = new List<ProjectImages>()
                {
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}Expand_Logo-01.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}Expand_Illustrator_Process-01.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}Expand_Poster.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}Social_Media_Activations.jpg"},
                                            new ProjectImages{imageRoute= $"~{imagePathExpand}EXPAND_Merch_2.0.jpg"},
                                            new ProjectImages{imageRoute= $"~{imagePathExpand}Web1-01.jpg"},
                                            new ProjectImages{imageRoute= $"~{imagePathExpand}WEBB3-01.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}WEBB4-01.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}WEBB5-01.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}College-Building2.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}Entrance.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}FrontDoors2.jpg"},
                                            new ProjectImages{imageRoute=$"~{imagePathExpand}SmokingArea1.jpg"},
                };
                List<ProjectImages> myVoteVideo = new List<ProjectImages>() {
                    new ProjectImages { imageRoute = "~/VideoProjects/PresentationVideo.mp4"},

                };
                List<ProjectImages> expandVideo = new List<ProjectImages>()
                {
                    new ProjectImages { imageRoute = "~/VideoProjects/Insta_Advert_Expand.mp4"},
                    new ProjectImages { imageRoute = "~/VideoProjects/Landscape_Animation.mp4"}
                };
                var projects = new Projects[]
                 {
                    new Projects{ProjectDescription="Anxieteen is an advertising campaign that promotes and raises awareness on the mental illness anxiety within teenagers. The campaign consists of an editorial which details accounts of various teenagers suffering from anxiety. The editorial also includes additional information about the different versions of the illness and what triggers it", ProjectTitle = "Anxieteen", DateCompleted="May 2020", Resolution="5334 x 5334 px", isVideo=false, ProjectImages=anxieteenMedia, Dir=imagePathAnxieteen},
                    new Projects{ProjectDescription="My Vote is a mobile voting app that enables users to cast their vote in public ballots from mobile devices. The app was designed with a large emphasis on security and accessibility. Additionally, My Vote provides unbiased information on the irish voting system to the public.", ProjectTitle="My Vote",DateCompleted="November 2020", Resolution="5334 x 5334 px" ,isVideo=false, ProjectImages=myVoteMedia, Dir=imagePathMyVote},
                    new Projects{ProjectDescription="Rise Of The Whopper is a gaming application made to recruit a new younger generation of Whopper Lovers. The purpose of the game is to earn clown points by fighting continous waves of clown zombies. The application features in game weekly leaderboards where people can compete against each other to win vouchers for whopper burgers.", ProjectTitle="Rise of the Whopper", DateCompleted="September 2019", Resolution="5334 x 5334 px", isVideo=false, ProjectImages=whopperMedia, Dir=imagePathWhopper},
                    new Projects{ProjectDescription="Behind The Empire is a publication focused on the classic Star Wars movie ‘The Empire Strikes Back’ from 1980. The publication includes detailed infographics about the movie with interesting facts about its production. The vector illustrations bring the information to life.", ProjectTitle="Behind the Empire", Resolution="5334 x 5334 px",DateCompleted= "September 2019" ,isVideo=false, ProjectImages=empireMedia, Dir=imagePathEmpire},
                    new Projects{ProjectDescription="Pro Energy Homes is a unique Credit Union initiative supported by the SEAI to make warmer, healthier and energy efficient homes more affordable. During my internship, I was given the freedom to produce a creative option for this identity. The following was my design and it was selected for the Credit Union initiative.", ProjectTitle="Pro Energy Homes", DateCompleted="April 2019", Resolution="5334 x 5334 px", isVideo=false, ProjectImages=proHomes, Dir=imagePathHomes },
                    new Projects{ProjectDescription="EXPAND is a promotional campaign for LSAD’s Fashion, Knitwear and Textiles 2020 graduate showcase.The name EXPAND personifies the students growth and progression throughout the four year course.The identity itself is inspired by contemporary design.",ProjectTitle="Expand",DateCompleted="September 2019", Resolution="5334 x 5334 px", isVideo=false, ProjectImages=expandMedia, Dir=imagePathExpand },
                    new Projects{ProjectDescription="My Vote is a mobile voting app that enables users to cast their vote in public ballots from mobile devices. The app was designed with a large emphasis on security and accessibility. Additionally, My Vote provides unbiased information on the irish voting system to the public.", ProjectTitle="My Vote",DateCompleted="November 2020", Resolution="5334 x 5334 px" ,isVideo=true, ProjectImages= myVoteVideo, Dir="/VideoProjects/"},
                    new Projects{ProjectDescription="EXPAND is a promotional campaign for LSAD’s Fashion, Knitwear and Textiles 2020 graduate showcase.The name EXPAND personifies the students growth and progression throughout the four year course.The identity itself is inspired by contemporary design.",ProjectTitle="Expand",DateCompleted="September 2019", Resolution="5334 x 5334 px", isVideo=true, ProjectImages=expandVideo, Dir="/VideoProjects/" },
                };
                foreach (Projects project in projects)
                {
                    context.Projects.Add(project);
                }
                context.SaveChanges();
            }
            if (!context.ProjectComments.Any())
            {
  
                var applciationUsers =  context.Users.ToList();
                var projects =  context.Projects.ToList();

                List<string> s = new List<string>();
                List<int> i = new List<int>();
                foreach(ApplicationUser a in applciationUsers)
                {
                    s.Add(a.Id);                    
                }
                foreach(Projects a in projects)
                {
                    i.Add(a.ProjectsID);
                }
                List<ProjectComments> projectComments = new List<ProjectComments>()
                {
                    new ProjectComments(){ApplicationUserID = s[0], ProjectID = i[0], CommentTimeStamp= DateTime.Today, CommentText="Great effort at tackling modern problems"},
                    new ProjectComments(){ApplicationUserID = s[0], ProjectID = i[2], CommentTimeStamp= DateTime.Today, CommentText="As a star wars lover i found great amusement in this"},
                    new ProjectComments(){ApplicationUserID = s[1],  ProjectID = i[1],CommentTimeStamp= DateTime.Today, CommentText="A great new method to vote, we could see more of this in the future"},
                    new ProjectComments(){ApplicationUserID = s[1],  ProjectID = i[1], CommentTimeStamp= DateTime.Today, CommentText="I want a burger now"},
                };
                foreach(ProjectComments p in projectComments)
                {
                    context.ProjectComments.Add(p);
                }
                context.SaveChanges();



            }
        }
    }
}
