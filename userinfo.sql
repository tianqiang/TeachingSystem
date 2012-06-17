-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 17 日 05:41
-- 服务器版本: 5.5.8
-- PHP 版本: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `userinfo`
--

-- --------------------------------------------------------

--
-- 表的结构 `course`
--

CREATE TABLE IF NOT EXISTS `course` (
  `Name` varchar(20) NOT NULL,
  `Teacher` varchar(20) NOT NULL,
  `Account` varchar(20) NOT NULL,
  `Place` varchar(20) NOT NULL,
  `Number` varchar(8) NOT NULL,
  `Content` varchar(150) NOT NULL,
  `PreCourse` varchar(20) NOT NULL,
  `Majoy` varchar(20) NOT NULL,
  `MaxNum` int(4) NOT NULL,
  `Score` float NOT NULL,
  `Type` varchar(5) NOT NULL,
  `TestType` varchar(20) NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `course`
--

INSERT INTO `course` (`Name`, `Teacher`, `Account`, `Place`, `Number`, `Content`, `PreCourse`, `Majoy`, `MaxNum`, `Score`, `Type`, `TestType`) VALUES
('人工智能', '周密', '2010000003', 'C202', '088123', '关于人工智能', '', '软件工程 计算机科学', 80, 3, '选修', '期末统考'),
('C#', '谭浩强', '2010051717', '教308', '088345', '熟悉C#的运用', '', '软件工程 计算机科学', 120, 2, '选修', '期末统考'),
('敏捷开发', '陈双平', '2010000002', 'C201', '088602', '一种以测试驱动开发，适合小团体的开发思想', '软件工程', '软件工程 计算机科学与技术', 120, 2, '选修', '期末统考'),
('编译原理', '李军', '2010000001', '珠海教学楼', '088611', '从底层了解编译器的行为', 'C++', '', 120, 2, '必修', '期末统考'),
('计算机系统结构', '李军', '2010000001', '教304', '880122', '计算机系统相关原理设计', '计算机组成原理', '软件工程 计算机科学技术', 120, 3, '选修', '期末统考'),
('ftfrs', '李军', '2010000001', 'c244', '880988', 'xgghh', '', '', 80, 2, '选修', '期末统考'),
('计算机组成原理', '李军', '2010000001', 'C105', '881224', '计算机硬件组成结构', '数字逻辑电路', '', 100, 3, '必修', '期末统考'),
('图论', '陈双平', '2010000002', '教204', '890871', '离散数学的图论方面', '', '', 200, 2, '必修', '期末统考');

-- --------------------------------------------------------

--
-- 表的结构 `job`
--

CREATE TABLE IF NOT EXISTS `job` (
  `KeyNumber` int(11) NOT NULL AUTO_INCREMENT,
  `CourseNumber` varchar(8) NOT NULL,
  `Homework` varchar(300) NOT NULL,
  `Answer` varchar(300) NOT NULL,
  PRIMARY KEY (`KeyNumber`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=14 ;

--
-- 转存表中的数据 `job`
--

INSERT INTO `job` (`KeyNumber`, `CourseNumber`, `Homework`, `Answer`) VALUES
(2, '088345', 'C#期末作业 用C#写万年历 程式专案档http://yo801106.wikidot.com/local--files/c/C%23%E6%9C%9F%E6%9C%AB%E4%BD%9C%E6%A5%AD.zip 万年历判断...', ''),
(7, '088123', '做一个汤姆猫软件', ''),
(10, '088611', '做一份全息存储的调查', ''),
(11, '880122', '编写一个保龄球计分程序', ''),
(12, '880122', '编写一个保龄球计分程序', ''),
(13, '088611', 'ghjdf', '');

-- --------------------------------------------------------

--
-- 表的结构 `studentcourse`
--

CREATE TABLE IF NOT EXISTS `studentcourse` (
  `KeyNum` int(11) NOT NULL AUTO_INCREMENT,
  `Account` varchar(20) NOT NULL,
  `CourseName` varchar(15) NOT NULL,
  `CommentToTeacher` varchar(150) NOT NULL,
  `Number` varchar(20) NOT NULL,
  `Score` int(11) NOT NULL,
  `CommentToStudent` varchar(150) NOT NULL,
  `State` int(4) NOT NULL,
  PRIMARY KEY (`KeyNum`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=33 ;

--
-- 转存表中的数据 `studentcourse`
--

INSERT INTO `studentcourse` (`KeyNum`, `Account`, `CourseName`, `CommentToTeacher`, `Number`, `Score`, `CommentToStudent`, `State`) VALUES
(5, '2009051729', '敏捷开发', '', '088602', 85, '', 1),
(12, '2009051729', '图论', '', '890871', 0, '', 0),
(27, '2009051725', '敏捷开发', '', '088602', 0, '', 0),
(29, '2009051725', '计算机系统结构', '', '880122', 0, '不错', 0),
(31, '2009051729', 'C#', '', '088345', 0, '', 0),
(32, '2009051729', '敏捷开发', '', '088602', 0, '', 0);

-- --------------------------------------------------------

--
-- 表的结构 `time`
--

CREATE TABLE IF NOT EXISTS `time` (
  `Number` varchar(8) NOT NULL,
  `Day` varchar(10) NOT NULL,
  `Week` varchar(10) NOT NULL,
  `TimeSpan` varchar(50) NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `time`
--

INSERT INTO `time` (`Number`, `Day`, `Week`, `TimeSpan`) VALUES
('088123', '星期四', '1,18', '1,3'),
('088345', '星期一', '1,16', '1,2'),
('088602', '星期五', '1,16', '1,2'),
('088611', '星期三', '1,16', '1,3'),
('880122', '星期一', '1,16', '1,3'),
('880988', '星期一', '1,16', '1,3'),
('881224', '星期四', '1,16', '1,3'),
('890871', '星期三', '1,16', '7,8');

-- --------------------------------------------------------

--
-- 表的结构 `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `Account` varchar(20) NOT NULL,
  `Name` varchar(10) NOT NULL,
  `NickName` varchar(20) NOT NULL,
  `Email` varchar(30) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Sex` varchar(5) NOT NULL,
  `College` varchar(30) NOT NULL,
  `Major` varchar(30) NOT NULL,
  `Role` varchar(5) NOT NULL,
  PRIMARY KEY (`Account`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `user`
--

INSERT INTO `user` (`Account`, `Name`, `NickName`, `Email`, `Password`, `Sex`, `College`, `Major`, `Role`) VALUES
('1234567890', '王小二', '小二', '11111111@qq.com', '123456', '男', '电气信息学院', '软件工程', '学生'),
('2009000001', '欧阳锋', '', '222222@qq.com', '000001', '男', '管理学院', '行政管理', '教师'),
('2009000002', '慕容淼', '', '4314312@qq.com', '000002', '女', '文学院', '语言文学', '学生'),
('2009000006', '薛之萱', '', '230451@139.com', '000006', '女', '经济学院', '金融工程', '学生'),
('2009000007', '赵飞燕', '', '152000@qq.com', '000007', '女', '电气信息学院', '软件工程', '学生'),
('2009000010', '赵婉夕', '', '200010@163.com', '000010', '女', '国际商学院', '工商管理', '学生'),
('2009051724', '戴礼荣', '礼荣哥', '30585456@2384', '051724', '男', '电气信息学院', '软件工程', '学生'),
('2009051725', '邵天强', '', '151695276@qq.com', '051725', '男', '电气信息学院', '软件工程', '学生'),
('2009051729', '陈志鹏', '玄幻风', '305867134@qq.com', '051729', '男', '电气信息学院', '软件工程', '学生'),
('2010000001', '李军', '', '001@qq.com', '000001', '男', '电气信息学院', '', '教师'),
('2010000002', '陈双平', '', '002@qq.com', '000002', '男', '电气信息学院', '', '教师'),
('2010000003', '周密', '', '003@qq.com', '000003', '男', '电气信息学院', '', '教师'),
('2010000010', '孙世良', '', '100000@qq.com', '000010', '男', '电气信息学院', '', '教师'),
('2010051717', '谭浩强', '牛人', '0051712@163.com', 'aa051717', '男', '电气信息学院', '计算机科学与技术', '教师');
