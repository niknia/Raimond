const fs = require('fs');
const path = require('path');
const { execSync } = require('child_process');

// Directories/files to delete
const dirsToDelete = [
  'node_modules',
  'dist',
  'tmp',
  'build',
  'coverage',
  'pnpm-lock.yaml',
  '.nx',
  '.next',
];

// Recursive deletion function
const recursiveDelete = (dirPath) => {
  if (fs.existsSync(dirPath)) {
    try {
      fs.rmSync(dirPath, { recursive: true, force: true });
      console.log(`✅ Removed: ${dirPath}`);
    } catch (err) {
      console.warn(`⚠️ Failed to remove ${dirPath}: ${err.message}`);
    }
  }
};

// Walk through directories and clean node_modules
const walkAndClean = (dir, targetDir = 'node_modules') => {
  try {
    fs.readdirSync(dir).forEach((f) => {
      const fullPath = path.join(dir, f);
      if (fs.statSync(fullPath).isDirectory()) {
        if (f === targetDir) {
          recursiveDelete(fullPath);
        } else {
          walkAndClean(fullPath, targetDir);
        }
      }
    });
  } catch (err) {
    console.warn(`⚠️ Error reading directory ${dir}: ${err.message}`);
  }
};

// Main cleanup function
const clean = () => {
  const root = process.cwd();

  // Delete top-level directories/files
  dirsToDelete.forEach((item) => {
    recursiveDelete(path.join(root, item));
  });

  // Clean nested node_modules in apps and packages
  const nestedDirs = ['apps', 'packages'];
  nestedDirs.forEach((nestedDir) => {
    const fullPath = path.join(root, nestedDir);
    if (fs.existsSync(fullPath)) {
      walkAndClean(fullPath);
    }
  });

  console.log('✅ Clean complete!');
};

// Execute the cleanup
clean();