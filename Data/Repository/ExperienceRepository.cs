﻿using Data.ApplicationContext;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        public ExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateExperience(Experience experience)
        {
            _context.Add(experience);
            Save();
        }

        public void DeleteExperience(Experience experience)
        {
            _context.Remove(experience);
            Save();
        }

        public async Task<Experience> GetExperienceById(int experienceId)
        {
            return await _context.Experiences.SingleOrDefaultAsync(e=> e.ExperienceId == experienceId);
        }

        public async Task<IEnumerable<Experience>> GetExperiencesList(string search, int skip, int take)
        {
            return await _context.Experiences.Where(e=> EF.Functions.Like(e.ExperienceTitle,$"%{search}%")).OrderByDescending(e=> e.ExperienceId).Skip(skip).Take(take).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateExperience(Experience experience)
        {
            _context.Update(experience);
            Save();
        }
        public async Task<IEnumerable<Experience>> ShowExperiences()
        {
            return await _context.Experiences.OrderByDescending(e => e.ExperienceId).ToListAsync();
        }
        public async Task<int> GetExperiencesCount()
        {
            return await _context.Experiences.CountAsync();
        }
    }
}