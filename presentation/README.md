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

# Project structure

- `reveal.html`: reveal-md format of the standard `index.html` used by reveal-js: include reveal-plugins here
- `package.json`: includes scripts for starting presentation and creating pdf
- `content.md`: obvious...
- `custom.css`: obvious...
