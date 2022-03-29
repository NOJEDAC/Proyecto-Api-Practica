CREATE TABLE user(
  user_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  gender CHAR(1) NOT NULL,
  user_name VARCHAR(50) NOT NULL,
  email_address VARCHAR(50) NOT NULL,
  password_hash VARCHAR(255) NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(user_id),
  UNIQUE INDEX UQ_user_email_address(email_address),
  UNIQUE INDEX UQ_user_name(user_name)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;