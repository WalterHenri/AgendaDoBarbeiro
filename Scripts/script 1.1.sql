

CREATE TABLE IF NOT EXISTS enterprises (
    enterprise_id BIGSERIAL PRIMARY KEY,
    NAME VARCHAR(100) NOT NULL,
    SOCIAL_NAME VARCHAR(100) NOT NULL,
    CNPJ VARCHAR(20),
    CPF VARCHAR(20),
    PHONE VARCHAR(20)
);

INSERT INTO roles(description) VALUES ("USUARIO", "PROFISSIONAL", "ADMINISTRADOR");

CREATE TABLE IF NOT EXISTS professionals(
    professional_id BIGINT PRIMARY KEY REFERENCES users(user_id),
    whatsapp VARCHAR(50),
    first_message TEXT,
    description TEXT
);

ALTER TABLE barber_services ADD COLUMN enterprise_id BIGINT REFERENCES ENTERPRISES(enterprise_id)

CREATE TABLE IF NOT EXISTS work_days(
    work_day_id BIGSERIAL PRIMARY KEY,
    start_at time,
    closes_at time,
    day VARCHAR(20) CHECK ( DAY IN (('MONDAY'), ('TUESDAY'), ('WEDNESDAY'), ('THURSDAY'), ('FRIDAY'), ('SATURDAY'), ('SUNDAY')))
 );

CREATE TABLE IF NOT EXISTS professional_work_days(
    professional_id BIGINT REFERENCES professionals(professional_id),
    work_day_id BIGINT REFERENCES work_days(work_day_id)
);

ALTER TABLE professionals ADD COLUMN enterprise_id BIGINT REFERENCES enterprises(enterprise_id)



