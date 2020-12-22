using IS4439_CA2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Data
{
    public class DBInitialiser
    {
        public static void Initialise(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Projects.Any())

            {
             

                var projects = new Projects[]
                 {
                new Projects{ProjectDescription="Anxieteen is an advertising campaign that promotes and raises awareness on the mental illness anxiety within teenagers. The campaign consists of an editorial which details accounts of various teenagers suffering from anxiety. The editorial also includes additional information about the different versions of the illness and what triggers it", ProjectTitle = "Anxieteen", DateCompleted="May 2020", Resolution="5334 x 5334 px", isVideo=false},
                 new Projects{ProjectDescription="My Vote is a mobile voting app that enables users to cast their vote in public ballots from mobile devices. The app was designed with a large emphasis on security and accessibility. Additionally, My Vote provides unbiased information on the irish voting system to the public.", ProjectTitle="My Vote",DateCompleted="November 2020", Resolution="5334 x 5334 px" ,isVideo=false},
                new Projects{ProjectDescription="Rise Of The Whopper is a gaming application made to recruit a new younger generation of Whopper Lovers. The purpose of the game is to earn clown points by fighting continous waves of clown zombies. The application features in game weekly leaderboards where people can compete against each other to win vouchers for whopper burgers.", ProjectTitle="Rise of the Whopper", DateCompleted="September 2019", Resolution="5334 x 5334 px", isVideo=false},
                new Projects{ProjectDescription="Behind The Empire is a publication focused on the classic Star Wars movie ‘The Empire Strikes Back’ from 1980. The publication includes detailed infographics about the movie with interesting facts about its production. The vector illustrations bring the information to life.", ProjectTitle="Behind the Empire", Resolution="5334 x 5334 px",isVideo=false},
                new Projects{ProjectDescription="Pro Energy Homes is a unique Credit Union initiative supported by the SEAI to make warmer, healthier and energy efficient homes more affordable. During my internship, I was given the freedom to produce a creative option for this identity. The following was my design and it was selected for the Credit Union initiative.", ProjectTitle="Pro Energy Homes", DateCompleted="April 2019", Resolution="5334 x 5334 px", isVideo=false },
                new Projects{ProjectDescription="EXPAND is a promotional campaign for LSAD’s Fashion, Knitwear and Textiles 2020 graduate showcase.The name EXPAND personifies the students growth and progression throughout the four year course.The identity itself is inspired by contemporary design.",ProjectTitle="Expand",DateCompleted="September 2019", Resolution="5334 x 5334 px", isVideo=false },
                new Projects{ProjectDescription="My Vote is a mobile voting app that enables users to cast their vote in public ballots from mobile devices. The app was designed with a large emphasis on security and accessibility. Additionally, My Vote provides unbiased information on the irish voting system to the public.", ProjectTitle="My Vote",DateCompleted="November 2020", Resolution="5334 x 5334 px" ,isVideo=true},
                new Projects{ProjectDescription="EXPAND is a promotional campaign for LSAD’s Fashion, Knitwear and Textiles 2020 graduate showcase.The name EXPAND personifies the students growth and progression throughout the four year course.The identity itself is inspired by contemporary design.",ProjectTitle="Expand",DateCompleted="September 2019", Resolution="5334 x 5334 px", isVideo=true },
                };
                foreach (Projects project in projects)
                {
                    context.Projects.Add(project);
                }
                context.SaveChanges();
            }
            string imagePathEmpire = "~/Projects/behind_the_empire/";
            string imagePathAnxieteen = "~/Projects/anxieteen/";
            string imagePathWhopper = "~/Projects/rise_of_the_whopper/";
            string imagePathMyVote = "~/Projects/my_vote/";
            string imagePathHomes = "~/Projects/pro_energy_homes/";
            string imagePathExpand = "~/Projects/expand/";
            if (!context.ProjectImages.Any())
            {
                var projectImages = new ProjectImages[] {
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxieteen.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Poster_1.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_2.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_3.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_4.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_5.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_6.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_7.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_8.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Anxiety_Spread_9.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Axieteen_Billboard_Mockup.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathAnxieteen}Mockup_Magazine.jpg", ProjectId=1},
                                            new ProjectImages{imageRoute=$"{imagePathMyVote}MyVote_Hero-01.jpg", ProjectId=2},
                                            new ProjectImages{imageRoute=$"{imagePathMyVote}MyVote_Page2.jpg", ProjectId=2},
                                            new ProjectImages{imageRoute=$"{imagePathWhopper}Rise_Of_The_Whopper-02.jpg", ProjectId=3},
                                            new ProjectImages{imageRoute=$"{imagePathWhopper}bkphones.jpg", ProjectId=3},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}Front_cover.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}Star_Wars_Overview.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}1_2.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}2_3.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}4_5.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}6_7.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}8_9.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}10_11.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}12_13.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}14_15.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}16_17.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathEmpire}18_19.jpg", ProjectId=4},
                                            new ProjectImages{imageRoute=$"{imagePathHomes}Pro_Energy_Homes_Logo.jpg", ProjectId=5},
                                            new ProjectImages{imageRoute=$"{imagePathHomes}Pro_Energy_Brochure.jpg", ProjectId=5},
                                            new ProjectImages{imageRoute=$"{imagePathHomes}Pro_Energy_Pull_Ups.jpg", ProjectId=5},
                                            new ProjectImages{imageRoute=$"{imagePathHomes}Pro_Energy_Web_Phone.jpg", ProjectId=5},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}Expand_Logo-01.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}Expand_Illustrator_Process-01.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}Expand_Poster.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}Social_Media_Activations.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute= $"{imagePathExpand}EXPAND_Merch_2.0.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute= $"{imagePathExpand}Web1-01.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute= $"{imagePathExpand}WEBB3-01.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}WEBB4-01.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}WEBB5-01.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}College-Building2.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}Entrance.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}FrontDoors2.jpg", ProjectId=6},
                                            new ProjectImages{imageRoute=$"{imagePathExpand}SmokingArea1.jpg", ProjectId=6},
                };
                foreach(ProjectImages pi in projectImages)
                {
                    context.ProjectImages.Add(pi);
                }
                context.SaveChanges();
            }
            if (!context.ProjectVideos.Any())
            {
                var projectVideos = new ProjectVideos[]
                {
                    new ProjectVideos { videoRoute = "~/VideoProjects/PresentationVideo.mp4", ProjectId = 2 },
                    new ProjectVideos { videoRoute = "~/VideoProjects/Insta_Advert_Expand.mp4", ProjectId = 6 },
                    new ProjectVideos { videoRoute = "~/VideoProjects/Landscape_Animation.mp4", ProjectId = 6 }
                };
                foreach (ProjectVideos pv in projectVideos)
                {
                    context.ProjectVideos.Add(pv);
                }
                context.SaveChanges();
            }
        }
    }
}
