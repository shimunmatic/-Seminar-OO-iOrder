CREATE TABLE role
(
  id   BIGINT IDENTITY
    PRIMARY KEY,
  role VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [user]
(
  username         VARCHAR(50) NOT NULL
    CONSTRAINT user_username_pk
    PRIMARY KEY,
  password         VARCHAR(50) NOT NULL,
  first_name       VARCHAR(50) NOT NULL,
  last_name        VARCHAR(50) NOT NULL,
  email            VARCHAR(50) NOT NULL,
  roleID           BIGINT      NOT NULL
    CONSTRAINT user_role_id_fk
    REFERENCES role,
  owner_id         VARCHAR(50)
    CONSTRAINT user_owner_username_fk
    REFERENCES [user],
  establishment_id BIGINT
)
GO

CREATE TABLE supplier
(
  id           BIGINT IDENTITY
    PRIMARY KEY,
  email        VARCHAR(50) NOT NULL,
  name         VARCHAR(50) NOT NULL,
  phone_number VARCHAR(50) NOT NULL,
  owner_id     VARCHAR(50)
    CONSTRAINT supplier_user_username_fk
    REFERENCES [user]
)
GO

CREATE UNIQUE INDEX supplier_id_uindex
  ON supplier (id)
GO

CREATE TABLE warehouse
(
  id       BIGINT IDENTITY
    PRIMARY KEY,
  address  VARCHAR(50) NOT NULL,
  zip      VARCHAR(50) NOT NULL,
  city     VARCHAR(50) NOT NULL,
  owner_id VARCHAR(50) NOT NULL
    CONSTRAINT warehouse_user_username_fk
    REFERENCES [user]
)
GO

CREATE UNIQUE INDEX warehouse_id_uindex
  ON warehouse (id)
GO

CREATE TABLE establishment
(
  id           BIGINT IDENTITY
    PRIMARY KEY,
  address      VARCHAR(50) NOT NULL,
  zip          VARCHAR(50) NOT NULL,
  city         VARCHAR(50) NOT NULL,
  owner_id     VARCHAR(50) NOT NULL
    CONSTRAINT establishment_user_username_fk
    REFERENCES [user],
  warehouse_id BIGINT      NOT NULL
    CONSTRAINT establishment_warehouse__fk
    REFERENCES warehouse,
  name         VARCHAR(50)
)
GO

CREATE UNIQUE INDEX establishment_id_uindex
  ON establishment (id)
GO

ALTER TABLE [user]
  ADD CONSTRAINT user_establishment_id_fk
FOREIGN KEY (establishment_id) REFERENCES establishment
GO

CREATE TABLE location
(
  id               BIGINT IDENTITY
    PRIMARY KEY,
  name             VARCHAR(50) NOT NULL,
  establishment_id BIGINT      NOT NULL
    CONSTRAINT location_establishment__fk
    REFERENCES establishment
)
GO

CREATE UNIQUE INDEX location_id_uindex
  ON location (id)
GO

CREATE TABLE category
(
  id       BIGINT IDENTITY
    PRIMARY KEY,
  name     VARCHAR(50) NOT NULL,
  owner_id VARCHAR(50) NOT NULL
    CONSTRAINT category_user_username_fk
    REFERENCES [user]
)
GO

CREATE UNIQUE INDEX category_id_uindex
  ON category (id)
GO

CREATE TABLE product
(
  id           BIGINT IDENTITY
    PRIMARY KEY,
  name         VARCHAR(50) NOT NULL,
  buying_price DECIMAL(18) NOT NULL,
  category_id  BIGINT      NOT NULL
    CONSTRAINT product_category__fk
    REFERENCES category,
  owner_id     VARCHAR(50) NOT NULL
    CONSTRAINT product_user_username_fk
    REFERENCES [user],
  supplier_id  BIGINT
    CONSTRAINT product_supplier_id_fk
    REFERENCES supplier
)
GO

CREATE UNIQUE INDEX product_id_uindex
  ON product (id)
GO

CREATE TABLE warehouse_product
(
  product_id    BIGINT      NOT NULL
    CONSTRAINT wearhouse_product_product__fk
    REFERENCES product,
  warehouse_id  BIGINT      NOT NULL
    CONSTRAINT wearhouse_product_warehouse_id_fk
    REFERENCES warehouse,
  quantity      INT         NOT NULL,
  selling_price DECIMAL(18) NOT NULL,
  id            BIGINT IDENTITY
    CONSTRAINT wearhouse_product_id_pk
    PRIMARY KEY
)
GO

CREATE TABLE [order]
(
  id               BIGINT IDENTITY
    PRIMARY KEY,
  date             DATETIME           NOT NULL,
  establishment_id BIGINT             NOT NULL
    CONSTRAINT order_establishemt__fk
    REFERENCES establishment,
  customer_id      VARCHAR(50)
    CONSTRAINT order_customer__fk
    REFERENCES [user],
  employee_id      VARCHAR(50)
    CONSTRAINT order_employee__fk
    REFERENCES [user],
  paid             SMALLINT DEFAULT 0 NOT NULL,
  location_id      BIGINT             NOT NULL
    CONSTRAINT order_location_id_fk
    REFERENCES location
)
GO

CREATE UNIQUE INDEX order_id_uindex
  ON [order] (id)
GO

CREATE TABLE order_pair
(
  id         BIGINT IDENTITY
    PRIMARY KEY,
  product_id BIGINT NOT NULL
    CONSTRAINT order_pair_product__fk
    REFERENCES product,
  quantity   INT    NOT NULL,
  order_id   BIGINT NOT NULL
    CONSTRAINT order_pair_order_id_fk
    REFERENCES [order]
)
GO

CREATE UNIQUE INDEX order_pair_id_uindex
  ON order_pair (id)
GO

