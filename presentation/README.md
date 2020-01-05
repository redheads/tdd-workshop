- Framework: [reveal-md](https://github.com/webpro/reveal-md)
- PDF export: [desktape](https://github.com/astefanutti/decktape)

# Initial setup

- `npm install -g reveal-md`
- `npm install -g decktape`
- install [FiraCode](https://github.com/tonsky/FiraCode) system-wide

# Normal usage

## Starting the slide show

- `npm start`

## Exporting PDF from slide show

- start the slide show (must be active!): `npm start`
- in a different shell: `npm run pdf`

(adapt for `vortrag` version accordingly: `npm run vortrag` and `npm run pdf-vortrag`)

On Arch Linux the `decktape` command requires the CLI option `--chrome-arg=--no-sandbox` (for details see "Errors - No usable sandbox!" section in [this issue](https://github.com/astefanutti/decktape)

# Reveal-md basics

`reveal-md` is a convenience wrapper around `reveal-js` for people who prefer using markdown instead of plain html. The main advantages is that you only have your content in the Git repository (and none of the reveal-js framework).

The basic command for starting a `reveal-md` presentation is `reveal-md your-content.md`.

The presentation can be customized:

- from the command line
- from the header section in the markdown file
- from a template file (i.e. reveal.html)

Customization options include:

- css
- reveal configs (i.e. plugins)
- reveal themes

# Splitting content into separate files

...is done via the file `preproc.js`.

IMPORTANT: Take care of line endings in markdown files, otherwise the mechanism won't work.

For details see `preproc.js`:

```javascript
// const LINE_SEPARATOR = '\r\n'; // <-- Windows default
const LINE_SEPARATOR = '\n'; // <-- Linux default

const preprocess = async (markdown, options) =>
    markdown
        .split(LINE_SEPARATOR)
//...
```

# Project structure

- `reveal.html`: reveal-md format of the standard `index.html` used by reveal-js: include reveal-plugins here
- `package.json`: includes scripts for starting presentation and creating pdf
- `slides/index.md`: the main file: include other files here using `FILE: other-file.md` syntax
