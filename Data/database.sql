DROP TABLE IF EXISTS "public"."mosh_project_person";
DROP TABLE IF EXISTS "public"."mosh_project";
DROP TABLE IF EXISTS "public"."mosh_person";
CREATE TABLE "public"."mosh_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "mosh_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."mosh_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "mosh_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."mosh_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "mosh_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."mosh_project" ("id", "project_name") VALUES (1, 'asp.net core');
INSERT INTO "public"."mosh_person" ("id", "person_name") VALUES (1, 'Mostafa Shubber');
ALTER TABLE "public"."mosh_project_person" ADD CONSTRAINT "fk_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."mosh_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."mosh_project_person" ADD CONSTRAINT "fk_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."mosh_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;