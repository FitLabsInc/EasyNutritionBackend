
﻿namespace EasyNutrition.API.Resources
{
    public class ExperienceResource
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UserResource User { get; set; }

    }

}
