-- Host: localhost:3306
-- Generation Time: Sep 25, 2016 at 10:48 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";
--
-- Table structure for table `tblLogin`
--
CREATE TABLE `tblLogin` (
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
--
-- Dumping data for table `tblLogin`
--
INSERT INTO `tblLogin` (`username`, `password`, `salt`) VALUES
('Burs@ry', '3fKDSkljh/1jqcYLBjBlJp4j2SnrESGCQ+wbGCKCp30=', 'IodAuW9cLowsnrX7vMHI4A=='),
('R0t@rycLUB', 'IhCCJRzhJZAXR2zXWsjrvJT5+3iEZOpdQS6/88g9ne8=', 'y37gpOEscPWiiXL1xXT2vg==');
--
-- Table structure for table `tblSchool`
--

CREATE TABLE `tblSchool` (
  `schoolID` int(10) NOT NULL,
  `schoolName` varChar(100) NOT NULL
  -- PRIMARY KEY (`schoolID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblSchool`
--

INSERT INTO `tblSchool` (`schoolID`,`schoolName`) VALUES
(0, 'All Students'),
(1, 'Ecole Acadienne de Truro'),
(2, 'Cobequid Educational Centre'),
(3, 'Colchester Christian Academy'),
(4, 'South Colchester Academy'),
(5, 'Tatamagouche Academy');

--
-- Table structure for table `tblstudent`
--

CREATE TABLE IF NOT EXISTS `tblStudent` (
  `appID` int(10) NOT NULL,
  `schoolID` int(10) NOT NULL,
  `infoID` int(10) NOT NULL,
  `fileID` int(10) NOT NULL,
  `appName` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `homePhone` varchar(100) NOT NULL,
  `cellPhone` varchar(100) NOT NULL,
  `gradeAvg` varchar(100) NOT NULL,
  `collegeName` varchar(100) NOT NULL,
  `hasLetter` varchar(100) NOT NULL,
  `progName` varchar(100) NOT NULL,
  `progStart` varchar(100) NOT NULL,
  `progDuration` varchar(100) NOT NULL
  -- PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblStudent`
--

INSERT INTO `tblStudent` (`appID`, `schoolID`, `infoID`,`fileID`,`appName`,`address`,`email`,`homePhone`,`cellPhone`,`gradeAvg`,`collegeName`,`hasLetter`,`progName`,`progStart`,`progDuration`) VALUES
(1,5,5,1, 'John Smith', '12 Prince St, Truro, NS B2N 2D4', 'johnsmith@hotmail.com','902-893-2367','902-890-4821','89','NSCC', 'yes', 'IT Web Programming','Sept 9, 2022','1 year'),
(2,4,4,2, 'Cathy Jones', '55 Main St, Bible Hill, NS B2N 4S2', 'cj@hotmail.com','902-897-1444','902-890-0074','94','Dal AC', 'no', 'Enviromental Science','Sept 6, 2022','2 year'),
(3,3,1,3, 'Ashley Tates', '346 Queen St, Truro, NS B2N 3T7', 'ashley@hotmail.com','902-895-2254','902-899-9961','91','NSCC', 'yes', 'Business Administration','Sept 9, 2022','3 year'),
(4,2,2,4, 'Taylor McLean', '239 Gorman Rd, North River, NS B6L 6E5', 'taymclean@hotmail.com','902-893-1533','902-890-4097','83','Acadia', 'yes', 'Geology','Sept 7, 2022','4 year'),
(5,1,3,5, 'Mark Adams', '605 Highway 2, Tatamagouche, NS B6L 2P7', 'markadams@hotmail.com','902-843-2188','902-814-0734','81','NSCC', 'yes', 'Law and Security','Sept 8, 2022','5 year');

--
-- Table structure for table `tblInfo`
--

CREATE TABLE `tblInfo` (
  `infoID` int(10) NOT NULL,
  `plans` varChar(500) NOT NULL,
  `finNeed` varChar(500) NOT NULL,
  `job` varChar(500) NOT NULL,
  `volunteer` varChar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --
-- -- Dumping data for table `tblInfo`
-- --

INSERT INTO `tblInfo` (`infoID`,`plans`,`finNeed`,`job`,`volunteer`) VALUES
(1, 'Go to school','I need money', 'Dishwasher','Red Cross'),
(2, 'Make money','Money', 'Cook','Homeless Shelter'),
(3, 'Get famous','More money', 'Influencer','Animal Shelter'),
(4, 'Be a CEO','Help me', 'Businessman','Firefighter'),
(5, 'Get a job','Give cash', 'Writer','Church');

--
-- Table structure for table `tblFiles`
--

CREATE TABLE `tblFiles` (
  `fileID` int(10) NOT NULL,
  `resume` varChar(100) NOT NULL,
  `transcript` varChar(100) NOT NULL
  -- `refLetter` varChar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --
-- -- Dumping data for table `tblFiles`
-- --

INSERT INTO `tblFiles` (`fileID`,`resume`,`transcript`) VALUES
(1, 'resume1', 'transcript1'),
(2, 'resume2', 'transcript2'),
(3, 'resume3', 'transcript3'),
(4, 'resume4', 'transcript4'),
(5, 'resume5', 'transcript5');


--
-- Indexes for dumped tables
--
--
-- Indexes for table `tblSchool`
--
ALTER TABLE `tblSchool`
  ADD PRIMARY KEY (`schoolID`);
--
-- Indexes for table `tblInfo`
--
ALTER TABLE `tblInfo`
  ADD PRIMARY KEY (`infoID`);
--
-- Indexes for table `tblFiles`
--
ALTER TABLE `tblFiles`
  ADD PRIMARY KEY (`fileID`);
--
-- Indexes for table `tblLogin`
--
ALTER TABLE `tblLogin`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `tblStudent`
--
ALTER TABLE `tblStudent`
  ADD PRIMARY KEY (`appID`),
  ADD KEY `schoolID` (`schoolID`),
  ADD KEY `infoID` (`infoID`),
  ADD KEY `fileID` (`fileID`);


--
-- AUTO_INCREMENT for dumped tables
--
--
-- AUTO_INCREMENT for table `tblSchool`
--
ALTER TABLE `tblSchool`
  MODIFY `schoolID` int(10) NOT NULL;

-- AUTO_INCREMENT for table `tblStudent`

ALTER TABLE `tblStudent`
  MODIFY `appID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tblInfo`
--
ALTER TABLE `tblInfo`
  MODIFY `infoID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tblFiles`
--
ALTER TABLE `tblFiles`
  MODIFY `fileID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;


--
-- Constraints for dumped tables
--
--
-- Constraints for table `tblStudent`
--
ALTER TABLE `tblStudent`
  ADD CONSTRAINT `tblStudent_ibfk_1` FOREIGN KEY (`schoolID`) REFERENCES `tblSchool` (`schoolID`),
  ADD CONSTRAINT `tblStudent_ibfk_2` FOREIGN KEY (`infoID`) REFERENCES `tblInfo` (`infoID`),
  ADD CONSTRAINT `tblStudent_ibfk_3` FOREIGN KEY (`fileID`) REFERENCES `tblFiles` (`fileID`);

-- ALTER TABLE `tblInfo`
--   ADD CONSTRAINT `tblStudent_ibfk_1` FOREIGN KEY (`infoID`) REFERENCES `tblStudent` (`infoID`) ON DELETE CASCADE ON UPDATE CASCADE;

-- ALTER TABLE `tblFiles`
--   ADD CONSTRAINT `tblStudent_ibfk_2` FOREIGN KEY (`fileID`) REFERENCES `tblStudent` (`fileID`) ON DELETE CASCADE ON UPDATE CASCADE;