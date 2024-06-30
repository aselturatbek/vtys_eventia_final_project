INSERT INTO Event (EventTitle, CategoryID, EventDetail, Location, EventDate, EventTime, ParticipationRequirements, ContactInfo, EventImageUrl)
VALUES
( 'Introduction to Machine Learning', 1, 'A workshop on the basics of machine learning.', 'Online', '2024-07-15', '10:00:00', 'Basic knowledge of Python', 'mlworkshop@education.com', 'https://images.unsplash.com/photo-1581093588401-2fe5c9b1d5d8'),
( 'City Marathon', 2, 'Annual marathon event in the city.', 'City Park', '2024-08-20', '07:00:00', 'Medical certificate required', 'info@citymarathon.com', 'https://images.unsplash.com/photo-1508881593-3e2670a7e370'),
( 'Gourmet Food Festival', 3, 'Taste the best dishes from top chefs.', 'Downtown Plaza', '2024-09-10', '11:00:00', NULL, 'foodfest@gourmet.com', 'https://images.unsplash.com/photo-1565299624946-b28f40a0ae38'),
( 'Art Exhibition: Modern Masters', 4, 'Exhibition showcasing modern art.', 'Art Gallery', '2024-10-05', '18:00:00', NULL, 'info@artgallery.com', 'https://images.unsplash.com/photo-1563805042-7684bfb72ce6'),
( 'Business Networking Event', 5, 'Meet and network with industry professionals.', 'Convention Center', '2024-07-20', '09:00:00', 'Business card required', 'networking@business.com', 'https://images.unsplash.com/photo-1556741533-f6acd6472c78'),
( 'Advanced Data Science Seminar', 1, 'In-depth seminar on data science techniques.', 'University Hall', '2024-11-10', '14:00:00', 'Experience in data science', 'dataseminar@university.com', 'https://images.unsplash.com/photo-1500522144261-ea64433bbe27'),
( 'Local Soccer Tournament', 2, 'Soccer tournament for local teams.', 'Sports Complex', '2024-08-25', '10:00:00', 'Team registration required', 'soccer@sportscomplex.com', 'https://images.unsplash.com/photo-1605296867304-46d5465a13f1'),
( 'Wine Tasting Event', 3, 'Sample fine wines from around the world.', 'Vineyard', '2024-09-15', '17:00:00', '21+ only', 'winetasting@vineyard.com', 'https://images.unsplash.com/photo-1571887016200-8b6230f7f2a9'),
( 'Theater Play: Shakespeare in the Park', 4, 'Open-air theater performance of Shakespeare.', 'Central Park', '2024-08-30', '19:00:00', 'Bring your own blanket', 'theater@park.com', 'https://images.unsplash.com/photo-1505475083727-e96550a5b13e'),
( 'Startup Pitch Night', 5, 'Pitch your startup idea to investors.', 'Tech Hub', '2024-07-25', '18:00:00', 'Pitch deck required', 'startup@techhub.com', 'https://images.unsplash.com/photo-1496181133206-80ce9b88a853'),
( 'AI in Education Symposium', 1, 'Symposium on AI applications in education.', 'Conference Center', '2024-12-01', '09:00:00', NULL, 'aisymposium@conference.com', 'https://images.unsplash.com/photo-1581092795364-3a36a792c6ed'),
( 'Charity Fun Run', 2, '5K run to raise money for charity.', 'City Square', '2024-09-20', '08:00:00', 'Fundraising minimum $100', 'charityrun@city.com', 'https://images.unsplash.com/photo-1604537529428-36d1c1f31d33'),
( 'Farm-to-Table Dinner', 3, 'Dinner featuring locally sourced ingredients.', 'Organic Farm', '2024-10-10', '19:00:00', NULL, 'dinner@organicfarm.com', 'https://images.unsplash.com/photo-1556911260-0dba9b4b3e60'),
( 'Art and Craft Fair', 4, 'Fair showcasing local artists and crafts.', 'Community Center', '2024-11-15', '10:00:00', 'Vendor registration required', 'craftfair@community.com', 'https://images.unsplash.com/photo-1517411032315-51b00a2041e0'),
( 'Entrepreneur Workshop', 5, 'Workshop on starting and growing your business.', 'Business School', '2024-07-30', '13:00:00', 'Pre-registration required', 'workshop@businessschool.com', 'https://images.unsplash.com/photo-1498050108023-c5249f4df085');


-- Tüm verileri sil
DELETE FROM Event;

-- ID sütununu sıfırla (MSSQL için)
DBCC CHECKIDENT ('Event', RESEED, 0);

INSERT INTO Event (EventTitle, CategoryID, EventDetail, Location, EventDate, EventTime, ParticipationRequirements, ContactInfo, EventImageUrl)
VALUES
( 'Introduction to Machine Learning', 1, 'A workshop on the basics of machine learning.', 'Online', '2024-07-15', '10:00:00', 'Basic knowledge of Python', '+1-555-1234', 'https://www.simplilearn.com/ice9/free_resources_article_thumb/Deep-Learning-vs-Machine-Learning.jpg'),
( 'City Marathon', 2, 'Annual marathon event in the city.', 'City Park, Boston', '2024-08-20', '07:00:00', 'Medical certificate required', '+1-555-5678', 'https://patch.com/img/cdn20/users/23773254/20231103/024649/styles/patch_image/public/221106-marathon-125___03140013125.jpg'),
( 'Gourmet Food Festival', 3, 'Taste the best dishes from top chefs.', 'Downtown Plaza, San Francisco', '2024-09-10', '11:00:00', NULL, '+1-555-9101', 'https://images.pexels.com/photos/958545/pexels-photo-958545.jpeg?cs=srgb&dl=pexels-chanwalrus-958545.jpg&fm=jpg'),
( 'Art Exhibition: Modern Masters', 4, 'Exhibition showcasing modern art.', 'Art Gallery, Chicago', '2024-10-05', '18:00:00', NULL, '+1-555-1213', 'https://observer.com/wp-content/uploads/sites/2/2020/03/Screen-Shot-2020-03-13-at-2.12.14-PM.png'),
( 'Business Networking Event', 5, 'Meet and network with industry professionals.', 'Convention Center, Los Angeles', '2024-07-20', '09:00:00', 'Business card required', '+1-555-1415', 'https://images.inc.com/uploaded_files/image/1920x1080/getty_597940046_152606.jpg'),
( 'Advanced Data Science Seminar', 1, 'In-depth seminar on data science techniques.', 'University Hall, Seattle', '2024-11-10', '14:00:00', 'Experience in data science', '+1-555-1617', 'https://builtin.com/sites/www.builtin.com/files/styles/og/public/2024-03/Data%20Science%201600x800.jpg'),
( 'Local Soccer Tournament', 2, 'Soccer tournament for local teams.', 'Sports Complex, Miami', '2024-08-25', '10:00:00', 'Team registration required', '+1-555-1819', 'https://www.soccerwire.com/wp-content/uploads/2023/05/usys-national-league-boys-mesa.jpg'),
( 'Startup Pitch Night', 5, 'Pitch your startup idea to investors.', 'Tech Hub, Austin', '2024-07-25', '18:00:00', 'Pitch deck required', '+1-555-2425', 'https://imageio.forbes.com/specials-images/imageserve/63f6203dc3acdad9f8902513/Growth-is-up-to-us/960x0.jpg?height=506&width=711&fit=bounds'),
( 'AI in Education Symposium', 1, 'Symposium on AI applications in education.', 'Conference Center, Boston', '2024-12-01', '09:00:00', NULL, '+1-555-2627', 'https://flawlessevents.net/wp-content/uploads/2023/12/Event_Agenda_A.I-1024x585.png')