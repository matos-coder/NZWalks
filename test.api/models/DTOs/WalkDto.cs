﻿using test.api.models.domain;

namespace test.api.models.DTOs
{
    public class WalkDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImgUrl { get; set; }

        public Guid difficultyId { get; set; }

        public Guid regionId { get; set; }
        public DifficultyDto difficulty { get; set; }

        public regionsdto region { get; set; }
    }
}
