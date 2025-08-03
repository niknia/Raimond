-- --------------------------------------------------------
-- Host:                           62.234.187.128
-- Server version:                 11.7.2-MariaDB-ubu2404 - mariadb.org binary distribution
-- Server OS:                      debian-linux-gnu
-- HeidiSQL version:              12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Export adnc_admin database structure
CREATE DATABASE IF NOT EXISTS `adnc_admin`;
USE `webdb`;

-- Export   table adnc_admin.sys_config structure
CREATE TABLE IF NOT EXISTS `sys_config` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `key` varchar(64) NOT NULL COMMENT 'Parameter Key',
  `name` varchar(64) NOT NULL COMMENT 'Parameter Name',
  `value` varchar(128) NOT NULL COMMENT 'Parameter Value',
  `remark` varchar(128) NOT NULL COMMENT 'Remarks',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='System Parameter';

-- Export   table adnc_admin.sys_dictionary structure
CREATE TABLE IF NOT EXISTS `sys_dictionary` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `code` varchar(32) NOT NULL,
  `name` varchar(32) NOT NULL,
  `remark` varchar(128) NOT NULL,
  `status` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Dictionary';

-- Export   table adnc_admin.sys_dictionary_data structure
CREATE TABLE IF NOT EXISTS `sys_dictionary_data` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `dictcode` varchar(32) NOT NULL,
  `label` varchar(32) NOT NULL,
  `value` varchar(32) NOT NULL,
  `tagtype` varchar(32) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `ordinal` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=658281065769542  COMMENT='Dictionary Data';

-- Exporting data for table adnc_admin.sys_config: ~0 rows
INSERT INTO `sys_config` (`id`, `createby`, `createtime`, `modifyby`, `modifytime`, `key`, `name`, `value`, `remark`) VALUES
	(654337157616325, 653335112912901, '2025-03-14 09:24:44.641988', 653335112912901, '2025-03-14 09:24:44.642019', 'weixin-key', 'WeChat API Key', '343sfsdfas', 'WeChat API Configuration');

-- Exporting data for table adnc_admin.sys_dictionary: ~4 rows
INSERT INTO `sys_dictionary` (`id`, `createby`, `createtime`, `modifyby`, `modifytime`, `code`, `name`, `remark`, `status`) VALUES
	(654231800692741, 653335112912901, '2025-03-14 02:16:02.842381', 653335112912901, '2025-03-14 02:16:02.847194', 'notice_type', 'Notification Type', '', 1),
	(654240219889733, 653335112912901, '2025-03-14 02:50:18.256197', 653335112912901, '2025-03-14 02:50:50.768281', 'notice_level', 'Notification Level', '', 1),
	(657672185329605, 653335112912901, '2025-03-23 19:35:00.432169', 653335112912901, '2025-03-23 19:37:07.391462', 'exchange_behavior', 'Customer Amount Change Type', '', 1),
	(657672310503365, 653335112912901, '2025-03-23 19:35:30.952618', 653335112912901, '2025-03-23 19:37:20.731602', 'exchage_status', 'Customer Amount Change Status', '', 1);

-- Exporting data for table adnc_admin.sys_dictionary_data: ~14 rows
INSERT INTO `sys_dictionary_data` (`id`, `createby`, `createtime`, `modifyby`, `modifytime`, `dictcode`, `label`, `value`, `tagtype`, `status`, `ordinal`) VALUES
	(654239258492997, 653335112912901, '2025-03-14 02:46:23.753258', 653335112912901, '2025-03-14 02:46:23.764096', 'notice_type', 'System Upgrade', '1', 'success', 1, 1),
	(654239345217605, 653335112912901, '2025-03-14 02:46:44.662244', 653335112912901, '2025-03-14 02:46:44.662315', 'notice_type', 'System Maintenance', '2', 'warning', 1, 2),
	(654239670661189, 653335112912901, '2025-03-14 02:48:04.130043', 653335112912901, '2025-03-14 02:48:17.928995', 'notice_type', 'Security Warning', '3', 'info', 1, 3),
	(654239799701573, 653335112912901, '2025-03-14 02:48:35.619266', 653335112912901, '2025-03-14 02:48:35.619300', 'notice_type', 'Holiday Notice', '4', 'primary', 1, 4),
	(654239873306693, 653335112912901, '2025-03-14 02:48:53.589871', 653335112912901, '2025-03-14 02:48:53.589908', 'notice_type', 'Company News', '5', 'danger', 1, 5),
	(654240025727045, 653335112912901, '2025-03-14 02:49:30.801847', 653335112912901, '2025-03-14 02:49:47.775236', 'notice_type', 'Other', '7', 'info', 1, 99),
	(654241282986053, 653335112912901, '2025-03-14 02:54:37.749547', 653335112912901, '2025-03-14 02:54:37.749570', 'notice_level', 'High', 'H', 'danger', 1, 1),
	(654241329270853, 653335112912901, '2025-03-14 02:54:49.049727', 653335112912901, '2025-03-14 02:55:31.410027', 'notice_level', 'Medium', 'M', 'primary', 1, 2),
	(654241459761221, 653335112912901, '2025-03-14 02:55:20.908143', 653335112912901, '2025-03-14 02:55:40.136094', 'notice_level', 'Low', 'L', 'info', 1, 3),
	(657672538613701, 653335112912901, '2025-03-23 19:36:26.683774', 653335112912901, '2025-03-25 12:55:08.585748', 'exchange_behavior', 'Admin Recharge', '8000', 'success', 1, 0),
	(657672875403205, 653335112912901, '2025-03-23 19:37:48.899555', 653335112912901, '2025-03-23 19:38:30.251295', 'exchage_status', 'Processing', '2000', 'primary', 1, 0),
	(657672927889349, 653335112912901, '2025-03-23 19:38:01.680144', 653335112912901, '2025-03-23 19:38:44.726467', 'exchage_status', 'Completed', '2008', 'success', 1, 3),
	(657673015670725, 653335112912901, '2025-03-23 19:38:23.111797', 653335112912901, '2025-03-23 19:38:48.499734', 'exchage_status', 'Failed', '2016', 'danger', 1, 6),
	(658281065769541, 653335112912901, '2025-03-25 12:52:32.845266', 653335112912901, '2025-03-25 12:55:21.807517', 'exchange_behavior', 'Order Transaction', '8008', 'primary', 1, 1);

-- Export structure for table adnc_admin.sys_eventtracker
CREATE TABLE IF NOT EXISTS `sys_eventtracker` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `eventid` bigint(20) NOT NULL,
  `trackername` varchar(50) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_sys_eventtracker_eventid_trackername` (`eventid`,`trackername`)
) ENGINE=InnoDB  COMMENT='Event Tracking/Processing Information';

-- Exporting data for table adnc_admin.sys_eventtracker: ~0 rows

-- Export structure for table adnc_admin.sys_menu
CREATE TABLE IF NOT EXISTS `sys_menu` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `parentid` bigint(20) NOT NULL COMMENT 'Parent Menu ID',
  `parentids` varchar(128) NOT NULL COMMENT 'Parent Menu IDs',
  `name` varchar(32) NOT NULL COMMENT 'Name',
  `perm` varchar(32) NOT NULL COMMENT 'Permission Code',
  `routename` varchar(64) NOT NULL COMMENT 'Route Name',
  `routepath` varchar(64) NOT NULL COMMENT 'Route Path',
  `type` varchar(16) NOT NULL COMMENT 'Menu Type',
  `component` varchar(64) NOT NULL COMMENT 'Component Configuration',
  `visible` tinyint(1) NOT NULL COMMENT 'Is Visible',
  `redirect` varchar(128) NOT NULL COMMENT 'Redirect Route Path',
  `icon` varchar(32) NOT NULL COMMENT 'Icon',
  `keepalive` tinyint(1) NOT NULL COMMENT 'Enable Page Cache',
  `alwaysshow` tinyint(1) NOT NULL COMMENT 'Always Show Single Child Route',
  `params` varchar(128) NOT NULL COMMENT 'Route Parameters',
  `ordinal` int(11) NOT NULL COMMENT 'Order Number',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Menu';

-- Exporting data for table adnc_admin.sys_menu: ~54 rows
INSERT INTO `sys_menu` (`id`, `createby`, `createtime`, `modifyby`, `modifytime`, `parentid`, `parentids`, `name`, `perm`, `routename`, `routepath`, `type`, `component`, `visible`, `redirect`, `icon`, `keepalive`, `alwaysshow`, `params`, `ordinal`) VALUES
	(653342080185029, 1000000000000, '2025-03-11 13:55:46.028479', 653337659433029, '2025-03-14 16:30:12.233442', 0, '[0]', 'System Management', '', '', '/system', 'CATALOG', 'Layout', 1, '/system/user', 'role', 1, 1, '', 1),
	(653342584296133, 1000000000000, '2025-03-11 13:57:49.016162', 653335112912901, '2025-03-14 09:10:34.425720', 653342080185029, '[0][653342080185029]', 'Menu Management', '', 'Menu', 'menu', 'MENU', 'system/menu/index', 1, '', 'menu', 1, 0, '', 4),
	(653343418946245, 1000000000000, '2025-03-11 14:01:12.781334', 653335112912901, '2025-03-12 02:18:57.594467', 653342584296133, '[0][653342080185029][653342584296133]', 'Add Menu', 'menu-create', '', '', 'BUTTON', '', 1, '', '', 1, 1, '', 1),
	(653389651534725, 653335112912901, '2025-03-11 17:09:20.259624', 653335112912901, '2025-03-12 02:18:51.063178', 653342584296133, '[0][653342080185029][653342584296133]', 'Edit Menu', 'menu-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '111=111', 2),
	(653524636169093, 653335112912901, '2025-03-12 02:18:35.485594', 653335112912901, '2025-03-12 02:18:35.490303', 653342584296133, '[0][653342080185029][653342584296133]', 'Delete Menu', 'menu-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 3),
	(653525628846981, 653335112912901, '2025-03-12 02:22:37.641550', 653335112912901, '2025-03-12 17:18:54.181204', 653342080185029, '[0][653342080185029]', 'Role Management', '', 'Role', 'role', 'MENU', 'system/role/index', 1, '', 'el-icon-Trophy', 1, 0, '', 2),
	(653525880882053, 653335112912901, '2025-03-12 02:23:39.176354', 653335112912901, '2025-03-12 02:23:39.176387', 653525628846981, '[0][653342080185029][653525628846981]', 'Add Role', 'role-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(653525982651269, 653335112912901, '2025-03-12 02:24:04.021653', 653335112912901, '2025-03-12 02:24:04.021694', 653525628846981, '[0][653342080185029][653525628846981]', 'Edit Role', 'role-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(653526164857733, 653335112912901, '2025-03-12 02:24:48.546878', 653335112912901, '2025-03-12 02:24:48.546926', 653525628846981, '[0][653342080185029][653525628846981]', 'Delete Role', 'role-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 3),
	(653526703580037, 653335112912901, '2025-03-12 02:27:00.032542', 653335112912901, '2025-03-15 01:31:28.153432', 653525628846981, '[0][653342080185029][653525628846981]', 'Search Role', 'role-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(653688386045317, 653335112912901, '2025-03-12 13:24:53.568100', 653335112912901, '2025-03-12 13:24:53.572926', 653342080185029, '[0][653342080185029]', 'Department Management', '', 'Dept', 'dept', 'MENU', 'system/dept/index', 1, '', 'el-icon-CoffeeCup', 1, 0, '', 1),
	(653688962147717, 653335112912901, '2025-03-12 13:27:13.929212', 653335112912901, '2025-03-12 13:27:13.929284', 653688386045317, '[0][653342080185029][653688386045317]', 'Add Department', 'org-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(653689048724869, 653335112912901, '2025-03-12 13:27:35.065392', 653335112912901, '2025-03-12 13:29:55.810715', 653688386045317, '[0][653342080185029][653688386045317]', 'Edit Department', 'org-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(653689299236229, 653335112912901, '2025-03-12 13:28:36.228932', 653335112912901, '2025-03-12 13:30:04.669707', 653688386045317, '[0][653342080185029][653688386045317]', 'Delete Department', 'org-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 3),
	(653689402680709, 653335112912901, '2025-03-12 13:29:01.481851', 653335112912901, '2025-03-15 01:30:38.237695', 653688386045317, '[0][653342080185029][653688386045317]', 'Search Department', 'org-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(653689923114373, 653335112912901, '2025-03-12 13:31:08.537851', 653335112912901, '2025-03-15 01:34:27.281727', 653342584296133, '[0][653342080185029][653342584296133]', 'Search Menu', 'menu-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(653745302407109, 653335112912901, '2025-03-12 17:16:29.199235', 653335112912901, '2025-03-12 17:18:47.314183', 653342080185029, '[0][653342080185029]', 'User Management', '', 'User', 'user', 'MENU', 'system/user/index', 1, '', 'el-icon-Avatar', 1, 0, '', 3),
	(653745429395397, 653335112912901, '2025-03-12 17:16:59.877507', 653335112912901, '2025-03-12 17:16:59.877621', 653745302407109, '[0][653342080185029][653745302407109]', 'Add User', 'user-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(653745520240581, 653335112912901, '2025-03-12 17:17:22.056285', 653335112912901, '2025-03-12 17:17:22.056480', 653745302407109, '[0][653342080185029][653745302407109]', 'Edit User', 'user-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(653756020922437, 653335112912901, '2025-03-12 18:00:05.906431', 653335112912901, '2025-03-15 01:32:11.120967', 653745302407109, '[0][653342080185029][653745302407109]', 'Search User', 'user-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(653787841784005, 653335112912901, '2025-03-12 20:09:34.640689', 653335112912901, '2025-03-12 20:09:34.644133', 653745302407109, '[0][653342080185029][653745302407109]', 'Reset Password', 'user-reset-password', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 5),
	(653804678302149, 653335112912901, '2025-03-12 21:18:05.045862', 653335112912901, '2025-03-12 21:18:05.050174', 653745302407109, '[0][653342080185029][653745302407109]', 'Delete User', 'user-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 6),
	(653805800937925, 653335112912901, '2025-03-12 21:22:39.031803', 653335112912901, '2025-03-12 21:22:39.031846', 653745302407109, '[0][653342080185029][653745302407109]', 'Import User', 'user-import', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 7),
	(653805917993413, 653335112912901, '2025-03-12 21:23:07.610400', 653335112912901, '2025-03-12 21:23:07.610542', 653745302407109, '[0][653342080185029][653745302407109]', 'Export User', 'user-export', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 8),
	(654225897013253, 653335112912901, '2025-03-14 01:52:01.907929', 653335112912901, '2025-03-14 01:53:03.674597', 653342080185029, '[0][653342080185029]', 'Dictionary Management', '', 'Dict', 'dict', 'MENU', 'system/dict/index', 1, '', 'el-icon-Discount', 1, 0, '', 5),
	(654226073489413, 653335112912901, '2025-03-14 01:52:44.618434', 653335112912901, '2025-03-14 01:52:44.618516', 654225897013253, '[0][654225897013253]', 'Add Dictionary', 'dict-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(654226273665029, 653335112912901, '2025-03-14 01:53:33.486091', 653335112912901, '2025-03-14 01:54:08.179769', 654225897013253, '[0][653342080185029][654225897013253]', 'Edit Dictionary', 'dict-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(654226371764229, 653335112912901, '2025-03-14 01:53:57.431053', 653335112912901, '2025-03-14 01:53:57.431184', 654225897013253, '[0][653342080185029][654225897013253]', 'Delete Dictionary', 'dict-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 3),
	(654226547773445, 653335112912901, '2025-03-14 01:54:40.402966', 653335112912901, '2025-03-15 01:34:59.384276', 654225897013253, '[0][653342080185029][654225897013253]', 'Search Dictionary', 'dict-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(654227048943621, 653335112912901, '2025-03-14 01:56:42.757506', 653335112912901, '2025-03-14 03:00:46.258079', 653342080185029, '[0][653342080185029]', 'Dictionary Data', '', 'DictData', 'dict-data', 'MENU', 'system/dict/data', 0, '', 'el-icon-CollectionTag', 1, 0, '', 6),
	(654227246395397, 653335112912901, '2025-03-14 01:57:30.967744', 653335112912901, '2025-03-14 01:57:30.967803', 654227048943621, '[0][653342080185029][654227048943621]', 'Add Dictionary Data', 'dictdata-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(654227348602885, 653335112912901, '2025-03-14 01:57:55.923311', 653335112912901, '2025-03-14 01:57:55.923356', 654227048943621, '[0][653342080185029][654227048943621]', 'Edit Dictionary Data', 'dictdata-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(654227455537157, 653335112912901, '2025-03-14 01:58:22.024924', 653335112912901, '2025-03-14 01:58:22.024962', 654227048943621, '[0][653342080185029][654227048943621]', 'Delete Dictionary Data', 'dictdata-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 3),
	(654227565006853, 653335112912901, '2025-03-14 01:58:48.754711', 653335112912901, '2025-03-15 01:35:45.770369', 654227048943621, '[0][653342080185029][654227048943621]', 'Search Dictionary Data', 'dictdata-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(654243405697093, 653335112912901, '2025-03-14 03:03:16.107668', 653335112912901, '2025-03-14 03:03:16.107695', 653342080185029, '[0][653342080185029]', 'System Configuration', '', 'Config', 'config', 'MENU', 'system/config/index', 1, '', 'el-icon-Setting', 1, 0, '', 7),
	(654332804104837, 653335112912901, '2025-03-14 09:07:02.281041', 653335112912901, '2025-03-14 09:07:02.289492', 654243405697093, '[0][653342080185029][654243405697093]', 'Add System Configuration', 'sysconfig-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(654332952756869, 653335112912901, '2025-03-14 09:07:38.205504', 653335112912901, '2025-03-14 09:07:47.036752', 654243405697093, '[0][653342080185029][654243405697093]', 'Edit System Configuration', 'sysconfig-update', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(654333157950085, 653335112912901, '2025-03-14 09:08:28.289495', 653335112912901, '2025-03-14 09:08:28.289582', 654243405697093, '[0][653342080185029][654243405697093]', 'Delete System Configuration', 'sysconfig-delete', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 3),
	(654333310177925, 653335112912901, '2025-03-14 09:09:05.451614', 653335112912901, '2025-03-15 01:36:15.355682', 654243405697093, '[0][653342080185029][654243405697093]', 'Search System Configuration', 'sysconfig-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 4),
	(654442132821701, 653337659433029, '2025-03-14 16:31:53.539063', 653335112912901, '2025-03-14 17:17:17.138145', 0, '[0]', 'Operations Management', '', '', '/maint', 'CATALOG', 'Layout', 1, '', 'el-icon-Opportunity', 1, 1, '', 2),
	(654442722764485, 653337659433029, '2025-03-14 16:34:17.507347', 653335112912901, '2025-03-23 19:31:39.244337', 654442132821701, '[0][654442132821701]', 'Operation Log', '', 'OperateLog', 'operatelog', 'MENU', 'maint/log/index', 1, '', 'el-icon-Search', 1, 0, '', 4),
	(654455068768133, 653335112912901, '2025-03-14 17:24:32.167647', 653335112912901, '2025-03-15 01:36:42.106666', 654442722764485, '[0][654442132821701][654442722764485]', 'Search Operation Log', 'operationlog-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(654523403131077, 653335112912901, '2025-03-14 22:02:35.101176', 653335112912901, '2025-03-23 19:31:34.280401', 654442132821701, '[0][654442132821701]', 'Login Log', '', 'LoginLog', 'loginlog', 'MENU', 'maint/log/loginlog', 1, '', 'el-icon-ChatLineRound', 1, 0, '', 3),
	(654523795179717, 653335112912901, '2025-03-14 22:04:10.598917', 653335112912901, '2025-03-15 01:37:04.449633', 654523403131077, '[0][654442132821701][654523403131077]', 'Search Login Log', 'loginlog-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(654788688007877, 653335112912901, '2025-03-15 16:02:03.031386', 653335112912901, '2025-03-15 16:02:03.039044', 653525628846981, '[0][653342080185029][653525628846981]', 'Set Role Permissions', 'role-setperms', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 5),
	(657665676666821, 653335112912901, '2025-03-23 19:08:31.507308', 653335112912901, '2025-03-23 19:40:08.537269', 0, '[0]', 'Customer Management', '', '', '/cust', 'CATALOG', 'Layout', 1, '/cust/customer', 'el-icon-Basketball', 1, 1, '', 3),
	(657666023151557, 653335112912901, '2025-03-23 19:09:55.957689', 653335112912901, '2025-03-23 19:16:31.039329', 657665676666821, '[0][657665676666821]', 'Customer Information', '', 'Customer', 'customer', 'MENU', 'cust/index', 1, '', 'el-icon-CircleCheck', 1, 0, '', 1),
	(657666337880005, 653335112912901, '2025-03-23 19:11:12.794987', 653335112912901, '2025-03-23 19:11:12.795007', 657666023151557, '[0][657665676666821][657666023151557]', 'Add Customer', 'customer-create', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(657666452023237, 653335112912901, '2025-03-23 19:11:40.660263', 653335112912901, '2025-03-23 19:11:40.660293', 657666023151557, '[0][657665676666821][657666023151557]', 'Search Customer', 'customer-search', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 2),
	(657666599712709, 653335112912901, '2025-03-23 19:12:16.718766', 653335112912901, '2025-03-23 19:12:16.718793', 657666023151557, '[0][657665676666821][657666023151557]', 'Customer Recharge', 'customer-recharge', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(657666958747589, 653335112912901, '2025-03-23 19:13:44.372250', 653335112912901, '2025-03-23 19:17:01.672635', 657665676666821, '[0][657665676666821]', 'Recharge Records', '', 'TransactionLog', 'transactionlog', 'MENU', 'cust/transactionlog', 1, '', 'el-icon-Grape', 1, 0, '', 1),
	(657667115956165, 653335112912901, '2025-03-23 19:14:22.752792', 653335112912901, '2025-03-23 19:14:22.752820', 657666958747589, '[0][657665676666821][657666958747589]', 'Search Recharge', 'customer-search-transactionlog', '', '', 'BUTTON', '', 1, '', '', 1, 0, '', 1),
	(657668727089093, 653335112912901, '2025-03-23 19:20:56.104578', 653335112912901, '2025-03-23 19:31:28.031597', 654442132821701, '[0][654442132821701]', 'Customer Center CAP', '', 'CustCapDashboard', 'eventbus-cust-dashboard', 'MENU', 'maint/eventbus/cust-cap-dashboard', 1, '', 'el-icon-Ship', 1, 0, '', 2),
	(657670470342597, 653335112912901, '2025-03-23 19:28:01.718644', 653335112912901, '2025-03-23 19:31:45.945099', 654442132821701, '[0][654442132821701]', 'Loki Logs', '', '', 'http://62.234.187.128:9010', 'EXTLINK', '', 1, '', 'el-icon-Cherry', 1, 0, '', 8),
	(657670977337285, 653335112912901, '2025-03-23 19:30:05.477607', 653335112912901, '2025-03-23 19:30:05.477628', 654442132821701, '[0][654442132821701]', 'Container Management', '', '', 'http://62.234.187.128:9000', 'EXTLINK', '', 1, '', 'el-icon-Compass', 1, 0, '', 1);

-- Export structure for table adnc_admin.sys_organization
CREATE TABLE IF NOT EXISTS `sys_organization` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `parentid` bigint(20) NOT NULL COMMENT 'Parent ID',
  `parentids` varchar(128) NOT NULL COMMENT 'Parent IDs',
  `code` varchar(16) NOT NULL COMMENT 'Code',
  `name` varchar(32) NOT NULL COMMENT 'Name',
  `status` tinyint(1) NOT NULL COMMENT 'Status',
  `ordinal` int(11) NOT NULL COMMENT 'Order Number',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Department';

-- Exporting data for table adnc_admin.sys_organization: ~6 rows
INSERT INTO `sys_organization` (`id`, `createby`, `createtime`, `modifyby`, `modifytime`, `parentid`, `parentids`, `ancestors`, `name`, `ordinal`, `status`) VALUES
	(653725132137989, 653335112912901, '2025-03-12 15:54:24.703512', 653335112912901, '2025-03-12 15:54:24.709316', 0, '[0]', 'microsoft', 'Microsoft China Co., Ltd.', 1, 1),
	(653726253618757, 653335112912901, '2025-03-12 15:58:58.512981', 653335112912901, '2025-03-12 15:58:58.517780', 653725132137989, '[0]', 'office', 'Office Business Division', 1, 1),
	(653726372808261, 653335112912901, '2025-03-12 15:59:27.369192', 653335112912901, '2025-03-12 15:59:27.369244', 653725132137989, '[0]', 'database', 'Database Business Division', 1, 2),
	(653726516561477, 653335112912901, '2025-03-12 16:00:02.464592', 653335112912901, '2025-03-12 16:10:30.737262', 653725132137989, '[0]', 'tools', 'Development Tools Division', 1, 3),
	(653729175238277, 653335112912901, '2025-03-12 16:10:51.633050', 653335112912901, '2025-03-12 16:10:51.633839', 653726516561477, '[0]', 'vscode', 'VSCode', 1, 1),
	(653729291642501, 653335112912901, '2025-03-12 16:11:19.988466', 653335112912901, '2025-03-13 13:59:53.811160', 653726516561477, '[0]', 'visualstudio', 'Visual Studio', 0, 3);

-- Export structure for table adnc_admin.sys_role
CREATE TABLE IF NOT EXISTS `sys_role` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `name` varchar(32) NOT NULL COMMENT 'Name',
  `code` varchar(32) NOT NULL COMMENT 'Code',
  `datascope` int(11) NOT NULL COMMENT 'Data Scope',
  `status` tinyint(1) NOT NULL COMMENT 'Status',
  `ordinal` int(11) NOT NULL COMMENT 'Order Number',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Role';

-- Exporting data for table adnc_admin.sys_role: ~2 rows
INSERT INTO `sys_role` (`id`, `createby`, `createtime`, `modifyby`, `modifytime`, `name`, `ordinal`, `status`) VALUES
	(653344679641925, 1000000000000, '2025-03-11 14:06:20.618864', 653335112912901, '2025-03-12 11:45:34.554147', 'System Administrator', 1, 1),
	(653682250118405, 653335112912901, '2025-03-12 12:59:55.116604', 653335112912901, '2025-03-24 23:57:04.926460', 'Visitor', 1, 1);

-- Export structure for table adnc_admin.sys_role_menu_relation
CREATE TABLE IF NOT EXISTS `sys_role_menu_relation` (
  `id` bigint(20) NOT NULL,
  `menuid` bigint(20) NOT NULL COMMENT 'Menu ID',
  `roleid` bigint(20) NOT NULL COMMENT 'Role ID',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Menu Role Relation';

-- Exporting data for table adnc_admin.sys_role_menu_relation: ~83 rows
INSERT INTO `sys_role_menu_relation` (`id`, `menuid`, `roleid`) VALUES
	(657671141251013, 653342080185029, 653344679641925),
	(657671141251014, 653688386045317, 653344679641925),
	(657671141251015, 653688962147717, 653344679641925),
	(657671141251016, 653689048724869, 653344679641925),
	(657671141251017, 653689299236229, 653344679641925),
	(657671141251018, 653689402680709, 653344679641925),
	(657671141251019, 653525628846981, 653344679641925),
	(657671141251020, 653525880882053, 653344679641925),
	(657671141251021, 653525982651269, 653344679641925),
	(657671141251022, 653526164857733, 653344679641925),
	(657671141251023, 653526703580037, 653344679641925),
	(657671141251024, 654788688007877, 653344679641925),
	(657671141251025, 653745302407109, 653344679641925),
	(657671141251026, 653745429395397, 653344679641925),
	(657671141251027, 653745520240581, 653344679641925),
	(657671141251028, 653756020922437, 653344679641925),
	(657671141251029, 653787841784005, 653344679641925),
	(657671141251030, 653804678302149, 653344679641925),
	(657671141251031, 653805800937925, 653344679641925),
	(657671141251032, 653805917993413, 653344679641925),
	(657671141251033, 653342584296133, 653344679641925),
	(657671141251034, 653343418946245, 653344679641925),
	(657671141251035, 653389651534725, 653344679641925),
	(657671141251036, 653524636169093, 653344679641925),
	(657671141251037, 653689923114373, 653344679641925),
	(657671141251038, 654225897013253, 653344679641925),
	(657671141251039, 654226073489413, 653344679641925),
	(657671141251040, 654226273665029, 653344679641925),
	(657671141251041, 654226371764229, 653344679641925),
	(657671141251042, 654226547773445, 653344679641925),
	(657671141251043, 654227048943621, 653344679641925),
	(657671141251044, 654227246395397, 653344679641925),
	(657671141251045, 654227348602885, 653344679641925),
	(657671141251046, 654227455537157, 653344679641925),
	(657671141251047, 654227565006853, 653344679641925),
	(657671141251048, 654243405697093, 653344679641925),
	(657671141251049, 654332804104837, 653344679641925),
	(657671141251050, 654332952756869, 653344679641925),
	(657671141251051, 654333157950085, 653344679641925),
	(657671141251052, 654333310177925, 653344679641925),
	(657671141251053, 654442132821701, 653344679641925),
	(657671141251054, 657670977337285, 653344679641925),
	(657671141251055, 654523403131077, 653344679641925),
	(657671141251056, 654523795179717, 653344679641925),
	(657671141251057, 654442722764485, 653344679641925),
	(657671141251058, 654455068768133, 653344679641925),
	(657671141251059, 657668727089093, 653344679641925),
	(657671141251060, 657670470342597, 653344679641925),
	(657671141251061, 657665676666821, 653344679641925),
	(657671141251062, 657666023151557, 653344679641925),
	(657671141251063, 657666337880005, 653344679641925),
	(657671141251064, 657666599712709, 653344679641925),
	(657671141251065, 657666452023237, 653344679641925),
	(657671141251066, 657666958747589, 653344679641925),
	(657671141251067, 657667115956165, 653344679641925),
	(658096326596997, 653342080185029, 653682250118405),
	(658096326596998, 653688386045317, 653682250118405),
	(658096326596999, 653689402680709, 653682250118405),
	(658096326597000, 653525628846981, 653682250118405),
	(658096326597001, 653526703580037, 653682250118405),
	(658096326597002, 653745302407109, 653682250118405),
	(658096326597003, 653756020922437, 653682250118405),
	(658096326597004, 653342584296133, 653682250118405),
	(658096326597005, 653689923114373, 653682250118405),
	(658096326597006, 654225897013253, 653682250118405),
	(658096326597007, 654226547773445, 653682250118405),
	(658096326597008, 654227048943621, 653682250118405),
	(658096326597009, 654227565006853, 653682250118405),
	(658096326597010, 654243405697093, 653682250118405),
	(658096326597011, 654333310177925, 653682250118405),
	(658096326597012, 654442132821701, 653682250118405),
	(658096326597013, 657670977337285, 653682250118405),
	(658096326597014, 657668727089093, 653682250118405),
	(658096326597015, 654523403131077, 653682250118405),
	(658096326597016, 654523795179717, 653682250118405),
	(658096326597017, 654442722764485, 653682250118405),
	(658096326597018, 654455068768133, 653682250118405),
	(658096326597019, 657670470342597, 653682250118405),
	(658096326597020, 657665676666821, 653682250118405),
	(658096326597021, 657666023151557, 653682250118405),
	(658096326601093, 657666452023237, 653682250118405),
	(658096326601094, 657666958747589, 653682250118405),
	(658096326601095, 657667115956165, 653682250118405);

-- Export structure for table adnc_admin.sys_role_user_relation
CREATE TABLE IF NOT EXISTS `sys_role_user_relation` (
  `id` bigint(20) NOT NULL,
  `userid` bigint(20) NOT NULL COMMENT 'User ID',
  `roleid` bigint(20) NOT NULL COMMENT 'Role ID',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='User Role Relation';

-- Exporting data for table adnc_admin.sys_role_user_relation: ~6 rows
INSERT INTO `sys_role_user_relation` (`id`, `userid`, `roleid`) VALUES
	(658284478040646, 658284478040645, 653682250118405),
	(658284667353670, 658284667353669, 653682250118405),
	(658284849875525, 658284256315973, 653682250118405),
	(658284876995141, 653337659433029, 653344679641925),
	(658284902369861, 653335112912901, 653344679641925),
	(658285201709637, 658285103086149, 653344679641925);

-- Export structure for table adnc_admin.sys_user
CREATE TABLE IF NOT EXISTS `sys_user` (
  `id` bigint(20) NOT NULL,
  `isdeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT 'Delete Flag',
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `account` varchar(32) NOT NULL COMMENT 'Account',
  `avatar` varchar(128) NOT NULL COMMENT 'Avatar Path',
  `birthday` datetime(6) DEFAULT NULL COMMENT 'Birthday',
  `deptid` bigint(20) NOT NULL COMMENT 'Department ID',
  `email` varchar(32) NOT NULL COMMENT 'Email',
  `name` varchar(32) NOT NULL COMMENT 'Name',
  `password` varchar(32) NOT NULL COMMENT 'Password',
  `mobile` varchar(11) NOT NULL COMMENT 'Mobile Number',
  `salt` varchar(6) NOT NULL COMMENT 'Password Salt',
  `gender` int(11) NOT NULL COMMENT 'Gender',
  `status` tinyint(1) NOT NULL COMMENT 'Status',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Administrator';

-- Exporting data for table adnc_admin.sys_user: ~10 rows
INSERT INTO `sys_user` (`id`, `isdeleted`, `createby`, `createtime`, `modifyby`, `modifytime`, `account`, `avatar`, `birthday`, `deptid`, `email`, `name`, `password`, `mobile`, `salt`, `gender`, `status`) VALUES
	(653335112912901, 0, 1000000000000, '2025-03-11 13:27:25.038287', 653335112912901, '2025-03-25 13:40:52.000000', 'alpha2008', '', '2025-03-11 14:11:08.062000', 653725132137989, 'user@example.com', 'Yu Da Mao', '3B6791E9AB14DFF278A3C2AF4B97F1E9', '', '846vm', 2, 1),
	(653337659433029, 0, 1000000000000, '2025-03-11 13:37:46.724327', 653335112912901, '2025-03-25 13:40:48.000000', 'alpha2009', '', '2025-03-11 13:24:22.360000', 653726253618757, 'user@example.com', 'Yu Da Mao', 'DE325BC108FD5B42D45500C3720F6628', '19964946688', '7vkvf', 2, 1),
	(653838533808773, 1, 653335112912901, '2025-03-12 23:35:50.884954', 653335112912901, '2025-03-12 23:36:58.000000', 'test1', '', NULL, 653725132137989, 'alphacn@foxmail.com', 'Test User', '86A961C57306BAC569B9FBB4EC6BA638', '', 'xfgiq', 0, 1),
	(653838713631365, 1, 653335112912901, '2025-03-12 23:36:34.421153', 653335112912901, '2025-03-12 23:36:58.000000', 'test2', '', NULL, 653726253618757, 'alphacn@foxmail.com', 'Test User 2', '0C54EFB2BAF6F1A13E2F39195D6AA8EB', '18898666555', 'so32e', 2, 1),
	(653838923670149, 1, 653335112912901, '2025-03-12 23:37:25.701911', 653335112912901, '2025-03-12 23:37:29.000000', 'test1', '', NULL, 653726253618757, 'alphacn@foxmail.com', 'Test User 1', '2A04D26E4CA62451402A1AC6F7515667', '', '3j8mi', 0, 0),
	(658284069145157, 1, 653335112912901, '2025-03-25 13:04:46.170019', 653335112912901, '2025-03-25 13:06:45.000000', 'alpha2000', '', NULL, 653725132137989, 'alpha2000@tom.com', '2000', '60861703F6F7102ECF0DBB09CABD841B', '', 'v3pfy', 1, 1),
	(658284256315973, 0, 653335112912901, '2025-03-25 13:05:31.786621', 653335112912901, '2025-03-25 13:40:45.000000', 'alpha2010', '', '2025-03-11 13:24:22.360000', 653725132137989, '2010@tom.com', '2010', 'C82AF7A87AE221D4D5C2624025BA318B', '', 'zi9j6', 1, 1),
	(658284478040645, 0, 653335112912901, '2025-03-25 13:06:25.922623', 653335112912901, '2025-03-25 13:40:41.000000', 'alpha2011', '', '2025-03-11 13:24:22.360000', 653725132137989, '2011@tom.com', '2011', '4B75645227A161690BD0CDEAD09B3067', '', '1v7ho', 1, 1),
	(658284667353669, 0, 653335112912901, '2025-03-25 13:07:12.139040', 653335112912901, '2025-03-25 13:40:37.000000', 'alpha2012', '', '2025-03-11 13:24:22.360000', 653725132137989, '2012@tom.com', '2012', '1011AD5C3D8665905E9358E385349C5B', '', '4ix1k', 1, 1),
	(658285103086149, 0, 653335112912901, '2025-03-25 13:08:58.517647', 653335112912901, '2025-03-25 13:40:32.000000', 'alpha2007', '', NULL, 653725132137989, '2007@tom.com', 'Yu Da Mao', '6DA705722E3CB40890B7CEA884821F7C', '', '3wjku', 2, 1);

-- Export structure for table adnc_admin.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `migrationid` varchar(150) NOT NULL,
  `productversion` varchar(32) NOT NULL,
  PRIMARY KEY (`migrationid`)
) ENGINE=InnoDB ;

-- Exporting data for table adnc_admin.__EFMigrationsHistory: ~7 rows
INSERT INTO `__EFMigrationsHistory` (`migrationid`, `productversion`) VALUES
	('20250311045441_Init20250311', '8.0.13'),
	('20250312052404_Update-2025031201', '8.0.13'),
	('20250312122420_Update-2025031202', '8.0.13'),
	('20250312140312_Update-2025031203', '8.0.13'),
	('20250313164005_Update2025031401', '8.0.13'),
	('20250316133304_Update2025031601', '8.0.13'),
	('20250317153239_Update2025031702', '8.0.13'),
	('20250323101948_Update25032301', '8.0.13');


-- Export adnc_cust database structure
CREATE DATABASE IF NOT EXISTS `adnc_cust`;
USE `adnc_cust`;

-- Export   table adnc_cust.cust_customer structure
CREATE TABLE IF NOT EXISTS `cust_customer` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `account` varchar(32) NOT NULL COMMENT 'Account',
  `password` varchar(32) NOT NULL COMMENT 'Password',
  `nickname` varchar(32) NOT NULL COMMENT 'Nickname',
  `realname` varchar(32) NOT NULL COMMENT 'Real Name',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Customer Table';

-- Export structure for table adnc_cust.cust_eventtracker
CREATE TABLE IF NOT EXISTS `cust_eventtracker` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `eventid` bigint(20) NOT NULL,
  `trackername` varchar(50) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time/Registration Time',
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_cust_eventtracker_eventid_trackername` (`eventid`,`trackername`)
) ENGINE=InnoDB  COMMENT='Event Tracking/Processing Information';

-- Export   table adnc_cust.cust_finance structure
CREATE TABLE IF NOT EXISTS `cust_finance` (
  `id` bigint(20) NOT NULL,
  `rowversion` datetime(6) NOT NULL COMMENT 'Row Version',
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time',
  `modifyby` bigint(20) NOT NULL COMMENT 'Last Updated By',
  `modifytime` datetime(6) NOT NULL COMMENT 'Last Update Time',
  `account` varchar(32) NOT NULL COMMENT 'Account',
  `balance` decimal(18,4) NOT NULL COMMENT 'Balance',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Customer Finance Table';

-- Export   table adnc_cust.cust_transactionlog structure
CREATE TABLE IF NOT EXISTS `cust_transactionlog` (
  `id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time',
  `customerid` bigint(20) NOT NULL COMMENT 'Customer ID',
  `account` varchar(32) NOT NULL COMMENT 'Account',
  `exchangetype` int(11) NOT NULL COMMENT 'Exchange Type',
  `exchagestatus` int(11) NOT NULL COMMENT 'Exchange Status',
  `changingamount` decimal(18,4) NOT NULL COMMENT 'Changing Amount',
  `amount` decimal(18,4) NOT NULL COMMENT 'Amount',
  `changedamount` decimal(18,4) NOT NULL COMMENT 'Changed Amount',
  `remark` varchar(128) NOT NULL COMMENT 'Remarks',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  COMMENT='Customer Financial Transaction Records';

-- Export   table adnc_cust.__EFMigrationsHistory structure
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `migrationid` varchar(150) NOT NULL,
  `productversion` varchar(32) NOT NULL,
  PRIMARY KEY (`migrationid`)
) ENGINE=InnoDB ;


-- Export adnc_maint database structure
CREATE DATABASE IF NOT EXISTS `adnc_maint`;
USE `adnc_maint`;

-- Export   table adnc_maint.sys_eventtracker structure
CREATE TABLE IF NOT EXISTS `sys_eventtracker` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `eventid` bigint(20) NOT NULL,
  `trackername` varchar(50) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'createby',
  `createtime` datetime(6) NOT NULL COMMENT 'createtime',
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_sys_eventtracker_eventid_trackername` (`eventid`,`trackername`)
) ENGINE=InnoDB  COMMENT='sys_eventtracker';

-- Export   table adnc_maint.__EFMigrationsHistory structure
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `migrationid` varchar(150) NOT NULL,
  `productversion` varchar(32) NOT NULL,
  PRIMARY KEY (`migrationid`)
) ENGINE=InnoDB ;


-- Export adnc_syslog database structure
CREATE DATABASE IF NOT EXISTS `adnc_syslog` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */;
USE `adnc_syslog`;

-- Export   table adnc_syslog.login_log structure
CREATE TABLE IF NOT EXISTS `login_log` (
  `Id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time',
  `device` varchar(200) NOT NULL COMMENT 'Device',
  `message` varchar(500) NOT NULL COMMENT 'Message',
  `succeed` tinyint(1) NOT NULL COMMENT 'Success Status',
  `userid` bigint(20) NOT NULL COMMENT 'User ID',
  `account` varchar(32) NOT NULL COMMENT 'Account',
  `username` varchar(32) NOT NULL COMMENT 'Username',
  `remoteipaddress` varchar(15) NOT NULL COMMENT 'Remote IP Address',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  COMMENT='Login Log';

-- Export   table adnc_syslog.operation_log structure
CREATE TABLE IF NOT EXISTS `operation_log` (
  `Id` bigint(20) NOT NULL,
  `createby` bigint(20) NOT NULL COMMENT 'Creator',
  `createtime` datetime(6) NOT NULL COMMENT 'Creation Time',
  `classname` varchar(256) NOT NULL COMMENT 'Class Name',
  `logtype` varchar(50) NOT NULL COMMENT 'Log Type',
  `message` varchar(4000) NOT NULL COMMENT 'Message',
  `method` varchar(256) NOT NULL COMMENT 'Method',
  `succeed` tinyint(1) NOT NULL COMMENT 'Success Status',
  `elapsedtime` bigint(20) NOT NULL COMMENT 'Elapsed Time',
  `userid` bigint(20) NOT NULL COMMENT 'User ID',
  `account` varchar(32) NOT NULL COMMENT 'Account',
  `username` varchar(32) NOT NULL COMMENT 'Username',
  `remoteipaddress` varchar(15) NOT NULL COMMENT 'Remote IP Address',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  COMMENT='Operation Log';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
