const fs = require('node:fs');
const path = require('node:path');
const archiver = require('archiver');

// Get the current date and time
const now = new Date();
const formattedDate = now.toISOString().replace(/[:.]/g, '-');

// Get the root directory name
const rootDir = path.basename(path.resolve(__dirname, '../'));

// Define the output zip file name
const outputFileName = `${rootDir}-${formattedDate}.zip`;
const outputFilePath = path.join(path.resolve(__dirname, '../'), outputFileName);

// Create a file to stream archive data to
const output = fs.createWriteStream(outputFilePath);
const archive = archiver('zip', {
  zlib: { level: 9 } // Sets the compression level
});

// Listen for all archive data to be written
output.on('close', () => {
  console.log(`${archive.pointer()} total bytes`);
  console.log('Backup has been finalized and the output file descriptor has closed.');
});

// Good practice to catch warnings (ie stat failures and other non-blocking errors)
archive.on('warning', (err) => {
  if (err.code === 'ENOENT') {
    console.warn('Warning:', err);
  } else {
    throw err;
  }
});

// Good practice to catch this error explicitly
archive.on('error', (err) => {
  throw err;
});

// Pipe archive data to the file
archive.pipe(output);

// Append files from a sub-directory, putting its contents at the root of archive
archive.glob('**/*', {
  cwd: path.resolve(__dirname, '../'),
  ignore: [
    'node_modules/**', 
    '**/node_modules/**',
    'node_modules', 
    '.next/**', 
    '**/.next/**',
    '.nx/**', 
    '.nx', 
    'dist/**', 
    'dist', 
    '**/dist/**',
    'next/**', 
    '**/next/**', 
    'next',
    'next', 
    '*.zip'
  ],
  dot: true
});

// Finalize the archive (ie we are done appending files but streams have to finish yet)
archive.finalize(); 