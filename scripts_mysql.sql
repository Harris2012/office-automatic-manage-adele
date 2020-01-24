CREATE TABLE `oam_notice` (
    `id` int NOT NULL AUTO_INCREMENT COMMENT 'Id',
    `title` varchar(100) NULL COMMENT 'Title',
    `body` varchar(100) NULL COMMENT 'Body',
    `category` varchar(100) NULL COMMENT 'Category',
    `data_status` int NULL DEFAULT 0 COMMENT 'DataStatus',
    `create_time` datetime NULL COMMENT 'CreateTime',
    `last_update_time` datetime NULL COMMENT 'LastUpdateTime',
  PRIMARY KEY (`id`)
) DEFAULT CHARSET=utf8mb4 COMMENT='Notice';

CREATE TABLE `oam_notice_category` (
    `id` int NOT NULL AUTO_INCREMENT COMMENT 'Id',
    `name` varchar(100) NULL COMMENT 'Name',
    `title` varchar(100) NULL COMMENT 'Title',
    `remark` varchar(100) NULL COMMENT 'Remark',
    `data_status` int NULL DEFAULT 0 COMMENT 'DataStatus',
    `create_time` datetime NULL COMMENT 'CreateTime',
    `last_update_time` datetime NULL COMMENT 'LastUpdateTime',
  PRIMARY KEY (`id`)
) DEFAULT CHARSET=utf8mb4 COMMENT='NoticeCategory';

