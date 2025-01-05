--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-01-05 12:02:40

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4892 (class 0 OID 18126)
-- Dependencies: 219
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."AspNetRoles" VALUES ('5c1486c2-b207-4dd9-8573-60d89b9d4b20', 'Instructor', 'INSTRUCTOR', NULL);


--
-- TOC entry 4895 (class 0 OID 18141)
-- Dependencies: 222
-- Data for Name: AspNetRoleClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4893 (class 0 OID 18133)
-- Dependencies: 220
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."AspNetUsers" VALUES ('ac524964-551e-4a37-91f9-98f64bc4c628', 'First2', 'Last2', 'WXpnSaFnWUwkyBo75jkdY48apIdCBDWdT+zBg3Z8bf4=', '2025-01-07 23:42:07.792373+03', '["31c27649-20cf-49ae-b8e7-4e67fff9d6a5","6792c845-f21a-4386-ac52-6693484ae95a","357da29f-1943-4c14-a59f-4c1663ed9c3c","0281e88a-98e6-4580-be16-5fb47cc6c3c8"]', 'user2', 'USER2', 'user2@gmail.con', 'USER2@GMAIL.CON', false, 'AQAAAAIAAYagAAAAEJ1a5WJ0FdiZ4MvFAEYa5sWa/FRLLE81nGhHlCnaSTbPmmG7VdH9K/KEG6sETlNJiw==', 'NVMYFUVJFRGGVE43EUV6C7VJ37XMPDWD', 'ca5dc444-817c-40b5-a859-07c06a702251', NULL, false, false, NULL, true, 0);
INSERT INTO public."AspNetUsers" VALUES ('687acdaf-1245-46f9-9d56-e13fe291a944', 'First1', 'Last1', 'Jvr56IrgOEQw+i1X2MU7EdPEnEEG+3pscXSC754hzO8=', '2025-01-07 23:53:51.802612+03', '["6bcf87d0-1104-4f67-8f77-e0a696f6f066","de383658-b3e6-40c5-b521-be45219353ea"]', 'user1', 'USER1', 'user1@gmail.com', 'USER1@GMAIL.COM', false, 'AQAAAAIAAYagAAAAEM2CCsbgnZTM04HVIIBXU5GCixahekTEo+C+6rQzqoSSBF/Epw4zyCvFLr+FTmWcaQ==', 'MXEOSW6KY434WKD3Q35PFZ57B3WAVM2A', 'a621194b-f57e-4d10-9263-76622c75dfdc', NULL, false, false, NULL, true, 0);
INSERT INTO public."AspNetUsers" VALUES ('260bf0b0-1ef1-46bc-98b3-37d8292cb751', 'Fatih', 'Terim', '6tBzYlh1UVKb8OPyFuErxWiyNYb58VyIlj+MPk0/Ubs=', '2025-01-07 23:56:13.147669+03', NULL, 'instructor1', 'INSTRUCTOR1', NULL, NULL, false, 'AQAAAAIAAYagAAAAEANowCUiiSULCjvZx6laek9sLE7KMsbH8v9wydXX5EDeVOoiLC4R8JoA0PaoT2X3nQ==', '1b504aba-55ad-4316-b2e6-326c23ba41fd', '2ec80c96-4906-4193-a442-14ec849609b2', NULL, false, false, NULL, false, 0);


--
-- TOC entry 4897 (class 0 OID 18154)
-- Dependencies: 224
-- Data for Name: AspNetUserClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4898 (class 0 OID 18166)
-- Dependencies: 225
-- Data for Name: AspNetUserLogins; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4899 (class 0 OID 18178)
-- Dependencies: 226
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."AspNetUserRoles" VALUES ('260bf0b0-1ef1-46bc-98b3-37d8292cb751', '5c1486c2-b207-4dd9-8573-60d89b9d4b20');


--
-- TOC entry 4900 (class 0 OID 18193)
-- Dependencies: 227
-- Data for Name: AspNetUserTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4901 (class 0 OID 18205)
-- Dependencies: 228
-- Data for Name: Courses; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Courses" VALUES ('6bcf87d0-1104-4f67-8f77-e0a696f6f066', 'React', 'Dive into the world of React, the powerful JavaScript library for building dynamic and responsive user interfaces. This course provides a comprehensive guide to React''s core concepts, tools, and ecosystem. Whether you''re a beginner looking to get started or an experienced developer wanting to refine your skills, this course will help you build modern, scalable web applications with confidence.', 25.99, 'Technology', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 10:42:20.394638+03', NULL);
INSERT INTO public."Courses" VALUES ('de383658-b3e6-40c5-b521-be45219353ea', 'ASP.NET', 'Explore the power of ASP.NET, Microsoft''s versatile framework for building robust and scalable web applications. This course offers a thorough introduction to ASP.NET''s core features, tools, and ecosystem. Whether you''re a beginner aiming to build dynamic web solutions or an experienced developer looking to deepen your skills, this course equips you to create modern, secure, and high-performance web applications with confidence.', 35.89, 'Technology', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 10:44:52.825601+03', NULL);
INSERT INTO public."Courses" VALUES ('31c27649-20cf-49ae-b8e7-4e67fff9d6a5', 'AYT Fizik', 'The AYT Physics course is designed to provide comprehensive guidance for students preparing for university entrance exams. This course helps you understand physical phenomena, grasp fundamental concepts, and solve questions quickly and accurately. Covering all topics from mechanics to electricity and magnetism, waves and optics to modern physics, it equips you with the knowledge and practical skills needed for success. ', 15.75, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:04:07.525336+03', NULL);
INSERT INTO public."Courses" VALUES ('6792c845-f21a-4386-ac52-6693484ae95a', 'AYT Matematik', 'The AYT Mathematics course is tailored for students preparing for university entrance exams, offering a deep dive into advanced mathematical concepts. This course covers key topics such as functions, derivatives, integrals, trigonometry, and analytical geometry, providing the knowledge and problem-solving techniques essential for exam success. This course ensures you’re well-prepared to achieve high scores and excel in your academic journey.', 29.99, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:06:15.14576+03', NULL);
INSERT INTO public."Courses" VALUES ('f557cd4f-75f0-43fc-a9fe-7b3bae41b5b0', 'AYT Kimya', 'The AYT Chemistry course prepares students for university entrance exams by covering advanced topics like chemical equilibrium, thermodynamics, electrochemistry, and organic chemistry. Through clear explanations and practical problem-solving strategies, this course helps students master complex concepts and improve their exam performance. Perfect for those building a foundation or refining their skills, it ensures confidence and success in tackling challenging chemistry questions.', 19.99, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:09:02.240123+03', NULL);
INSERT INTO public."Courses" VALUES ('0281e88a-98e6-4580-be16-5fb47cc6c3c8', 'AYT Biyoloji', 'The AYT Biology course is designed to help students excel in university entrance exams by providing a detailed understanding of advanced biology topics. ', 15.50, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:14:09.169223+03', NULL);
INSERT INTO public."Courses" VALUES ('93bb2b9b-e7a7-49b1-b176-a327df393747', 'AYT Tarih', 'The AYT History course is tailored to prepare students for university entrance exams by offering an in-depth exploration of key historical events, concepts, and themes. Covering topics such as the Ottoman Empire, modern Turkish history, world history, and political revolutions, this course ensures a thorough understanding of historical developments. With a focus on critical thinking and analytical skills, it helps students effectively approach exam questions and excel in their studies.', 9.75, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:19:10.797259+03', NULL);
INSERT INTO public."Courses" VALUES ('b5b28253-d299-4cb2-a595-a17fdca52c14', 'AYT Edebiyat', 'The AYT Literature course is designed to prepare students for university entrance exams by offering a comprehensive understanding of Turkish literature. Covering periods from Divan literature to Tanzimat, Servet-i Fünun, and modern Turkish literature, this course explores key authors, works, and movements.', 10.99, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:21:30.499884+03', NULL);
INSERT INTO public."Courses" VALUES ('893b9d94-a29f-4c12-acde-79880252d9fd', 'AYT Coğrafya', 'The AYT Geography course prepares students for university entrance exams by covering key topics such as climate, ecosystems, population, urbanization, and economic activities. With clear explanations and practical applications, this course helps students develop the knowledge and skills needed to approach questions confidently and achieve exam success.', 9.99, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:23:24.279735+03', NULL);
INSERT INTO public."Courses" VALUES ('357da29f-1943-4c14-a59f-4c1663ed9c3c', 'AYT Geometri', 'The AYT Geometry course is designed to help students excel in university entrance exams by focusing on essential topics like lines, angles, triangles, circles, polygons, and 3D shapes. With clear explanations and practical problem-solving techniques, this course builds a strong foundation and enhances analytical skills, ensuring students can confidently solve complex geometry questions and succeed in their exams.', 49.25, 'Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:24:59.223119+03', NULL);
INSERT INTO public."Courses" VALUES ('9a2f4e30-2072-4b7c-a9dd-47854f0df432', 'Business Essentials', 'This course provides a comprehensive introduction to key business concepts, including management, marketing, finance, and operations. Designed for aspiring entrepreneurs and professionals, it equips you with the knowledge and skills needed to understand business dynamics, make strategic decisions, and achieve success in today’s competitive environment.', 24.75, 'Business', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:28:01.305257+03', NULL);
INSERT INTO public."Courses" VALUES ('1d959d9a-a97c-4991-a1a9-7123ae596f2c', 'Machine Learning', 'This course covers Machine Learning fundamentals, including supervised, unsupervised, and deep learning. Students will learn key algorithms, data analysis, and model evaluation using tools like Python and TensorFlow. Hands-on projects emphasize practical applications in areas like healthcare and finance. Basic knowledge of Python, linear algebra, and probability is recommended.', 39.25, 'Technology, Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 11:57:59.074028+03', NULL);
INSERT INTO public."Courses" VALUES ('e5bdad3b-ed6b-48fe-851d-ba9f3cfb2c82', 'Generative AI', 'This course explores the fundamentals and applications of Generative AI, focusing on models like GANs (Generative Adversarial Networks), VAEs (Variational Autoencoders), and large language models. Students will learn how these systems generate realistic images, text, audio, and more. Hands-on projects include building generative models and applying them to creative tasks like content generation, image synthesis, and AI-driven design. ', 99.99, 'Technology, Science', '260bf0b0-1ef1-46bc-98b3-37d8292cb751', '2025-01-05 12:00:14.633319+03', NULL);


--
-- TOC entry 4904 (class 0 OID 18241)
-- Dependencies: 231
-- Data for Name: Baskets; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Baskets" VALUES ('445ede00-3784-4fe4-ada8-f70544c9a758', '687acdaf-1245-46f9-9d56-e13fe291a944', '31c27649-20cf-49ae-b8e7-4e67fff9d6a5');


--
-- TOC entry 4905 (class 0 OID 18256)
-- Dependencies: 232
-- Data for Name: Files; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Files" VALUES ('3f8c1fc4-7de9-4b0c-abd2-1a606194ec25', 'react.png', 'resource/course-images\react.png', 'LocalStorage', '2025-01-05 10:42:20.394638+03', NULL, 'CourseImageFile', '6bcf87d0-1104-4f67-8f77-e0a696f6f066', NULL);
INSERT INTO public."Files" VALUES ('5faed872-ea56-4584-b2cc-50fb49524588', 'aspnet.png', 'resource/course-images\aspnet.png', 'LocalStorage', '2025-01-05 10:44:52.825601+03', NULL, 'CourseImageFile', 'de383658-b3e6-40c5-b521-be45219353ea', NULL);
INSERT INTO public."Files" VALUES ('032ffa65-dcf1-40b5-beb2-7de48c4f158f', 'fizik.jpg', 'resource/course-images\fizik.jpg', 'LocalStorage', '2025-01-05 11:04:07.525336+03', NULL, 'CourseImageFile', '31c27649-20cf-49ae-b8e7-4e67fff9d6a5', NULL);
INSERT INTO public."Files" VALUES ('0e0da7f2-2baa-4395-8ba8-4fd0565fa29f', 'math.jpg', 'resource/course-images\math.jpg', 'LocalStorage', '2025-01-05 11:06:15.14576+03', NULL, 'CourseImageFile', '6792c845-f21a-4386-ac52-6693484ae95a', NULL);
INSERT INTO public."Files" VALUES ('d4604ddb-c4c7-4b12-90d8-4542e3ae1e72', 'kimya.jpg', 'resource/course-images\kimya.jpg', 'LocalStorage', '2025-01-05 11:09:02.240123+03', NULL, 'CourseImageFile', 'f557cd4f-75f0-43fc-a9fe-7b3bae41b5b0', NULL);
INSERT INTO public."Files" VALUES ('5e15d3ba-d8ca-4afd-985f-2856be49b017', 'biyoloji.jpg', 'resource/course-images\biyoloji.jpg', 'LocalStorage', '2025-01-05 11:14:09.169223+03', NULL, 'CourseImageFile', '0281e88a-98e6-4580-be16-5fb47cc6c3c8', NULL);
INSERT INTO public."Files" VALUES ('b2cc53a3-d30c-47a3-bffb-1da9be9b558f', 'tarih.jpg', 'resource/course-images\tarih.jpg', 'LocalStorage', '2025-01-05 11:19:10.797259+03', NULL, 'CourseImageFile', '93bb2b9b-e7a7-49b1-b176-a327df393747', NULL);
INSERT INTO public."Files" VALUES ('d7bd096b-0cdf-4245-a63b-b986f5cc68b1', 'edebiyat.jpg', 'resource/course-images\edebiyat.jpg', 'LocalStorage', '2025-01-05 11:21:30.499884+03', NULL, 'CourseImageFile', 'b5b28253-d299-4cb2-a595-a17fdca52c14', NULL);
INSERT INTO public."Files" VALUES ('b5799d6c-57d2-4747-b8d6-bcafa67e4a52', 'cografya.jpeg', 'resource/course-images\cografya.jpeg', 'LocalStorage', '2025-01-05 11:23:24.279735+03', NULL, 'CourseImageFile', '893b9d94-a29f-4c12-acde-79880252d9fd', NULL);
INSERT INTO public."Files" VALUES ('090a3ac9-dd7b-4a85-bd87-38dd1d544513', 'geometri.jpg', 'resource/course-images\geometri.jpg', 'LocalStorage', '2025-01-05 11:24:59.223119+03', NULL, 'CourseImageFile', '357da29f-1943-4c14-a59f-4c1663ed9c3c', NULL);
INSERT INTO public."Files" VALUES ('5911de32-ff4a-444b-ac93-c8311f3d7516', 'business.jpg', 'resource/course-images\business.jpg', 'LocalStorage', '2025-01-05 11:28:01.305257+03', NULL, 'CourseImageFile', '9a2f4e30-2072-4b7c-a9dd-47854f0df432', NULL);
INSERT INTO public."Files" VALUES ('1d98f6f3-3af7-4ab0-b962-46e5b4e6be12', 'yapayzeka.jpg', 'resource/course-images\yapayzeka.jpg', 'LocalStorage', '2025-01-05 11:57:59.074028+03', NULL, 'CourseImageFile', '1d959d9a-a97c-4991-a1a9-7123ae596f2c', NULL);
INSERT INTO public."Files" VALUES ('b2b63508-e0ef-464e-835b-5bc00ae43e24', 'generative_ai.png', 'resource/course-images\generative_ai.png', 'LocalStorage', '2025-01-05 12:00:14.633319+03', NULL, 'CourseImageFile', 'e5bdad3b-ed6b-48fe-851d-ba9f3cfb2c82', NULL);


--
-- TOC entry 4902 (class 0 OID 18217)
-- Dependencies: 229
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Orders" VALUES ('1f586cb7-fbec-424f-bc3f-d4dbcf49adc8', '687acdaf-1245-46f9-9d56-e13fe291a944', '["6bcf87d0-1104-4f67-8f77-e0a696f6f066","de383658-b3e6-40c5-b521-be45219353ea"]', 61.879999999999995, true, '60276878219503', '2025-01-05 11:40:40.328606+03', '2025-01-05 11:40:53.179343+03');
INSERT INTO public."Orders" VALUES ('147d55a0-01d8-41fc-8fea-d0a12c1117d5', 'ac524964-551e-4a37-91f9-98f64bc4c628', '["31c27649-20cf-49ae-b8e7-4e67fff9d6a5"]', 15.75, true, '898520866778', '2025-01-05 11:42:20.606346+03', '2025-01-05 11:42:32.622813+03');
INSERT INTO public."Orders" VALUES ('c8a6bcee-9294-4d97-9795-0313ccac3ab0', 'ac524964-551e-4a37-91f9-98f64bc4c628', '["6792c845-f21a-4386-ac52-6693484ae95a","357da29f-1943-4c14-a59f-4c1663ed9c3c"]', 79.24, true, '5733056480185', '2025-01-05 11:42:54.964648+03', '2025-01-05 11:43:03.156863+03');
INSERT INTO public."Orders" VALUES ('c14d78c9-06e4-4572-9086-bdc5efc0a01f', 'ac524964-551e-4a37-91f9-98f64bc4c628', '["0281e88a-98e6-4580-be16-5fb47cc6c3c8"]', 15.5, true, '37471292391274', '2025-01-05 11:43:47.032058+03', '2025-01-05 11:43:55.426128+03');
INSERT INTO public."Orders" VALUES ('f60d02eb-6634-4b46-9515-a5272e9c0926', '687acdaf-1245-46f9-9d56-e13fe291a944', '["31c27649-20cf-49ae-b8e7-4e67fff9d6a5"]', 15.75, false, NULL, '2025-01-05 11:53:57.380954+03', NULL);


--
-- TOC entry 4903 (class 0 OID 18229)
-- Dependencies: 230
-- Data for Name: Payments; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Payments" VALUES ('d7e6a7e0-0970-404b-9668-17a9e5b52d66', '687acdaf-1245-46f9-9d56-e13fe291a944', '1f586cb7-fbec-424f-bc3f-d4dbcf49adc8', 61.879999999999995, 1, '2025-01-05 11:40:40.360855+03', '2025-01-05 11:40:53.179343+03', NULL);
INSERT INTO public."Payments" VALUES ('f4245745-d4b1-4ca6-8c67-3f85de4c22ee', 'ac524964-551e-4a37-91f9-98f64bc4c628', '147d55a0-01d8-41fc-8fea-d0a12c1117d5', 15.75, 1, '2025-01-05 11:42:20.619754+03', '2025-01-05 11:42:32.622813+03', NULL);
INSERT INTO public."Payments" VALUES ('3a57b269-f288-4791-85a1-78a7dca5a041', 'ac524964-551e-4a37-91f9-98f64bc4c628', 'c8a6bcee-9294-4d97-9795-0313ccac3ab0', 79.24, 1, '2025-01-05 11:42:54.980882+03', '2025-01-05 11:43:03.156863+03', NULL);
INSERT INTO public."Payments" VALUES ('e363f2e8-c2de-4971-b771-13f9de7e503c', 'ac524964-551e-4a37-91f9-98f64bc4c628', 'c14d78c9-06e4-4572-9086-bdc5efc0a01f', 15.5, 1, '2025-01-05 11:43:47.035639+03', '2025-01-05 11:43:55.426128+03', NULL);
INSERT INTO public."Payments" VALUES ('558aff8a-16f7-49fc-a815-351258275c9c', '687acdaf-1245-46f9-9d56-e13fe291a944', 'f60d02eb-6634-4b46-9515-a5272e9c0926', 15.75, 0, '2025-01-05 11:53:57.408224+03', NULL, NULL);


--
-- TOC entry 4891 (class 0 OID 18121)
-- Dependencies: 218
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20250105072109_init_mig', '8.0.11');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250105073918_mig_2', '8.0.11');


--
-- TOC entry 4890 (class 0 OID 18116)
-- Dependencies: 217
-- Data for Name: logs; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4911 (class 0 OID 0)
-- Dependencies: 221
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


--
-- TOC entry 4912 (class 0 OID 0)
-- Dependencies: 223
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);


-- Completed on 2025-01-05 12:02:40

--
-- PostgreSQL database dump complete
--

